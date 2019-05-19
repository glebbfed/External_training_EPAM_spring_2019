using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text.RegularExpressions;

namespace Task1
{
    public class UrlExporter
    {
        Regex urlAddressReg = new Regex(@"^http[s]{0,1}:\/\/([^?\/]+(\/)?){1,}((?<=\/)[^\?\/\=\&]+\?([^\?\/\=\&]+=[^\?\/\=\&]+(&[^\?\/\=]+=[^\?\/\=\&]+){0,}){0,1}[\/]{0,1}){0,1}$");
        Regex partWithoutParamsReg = new Regex(@"(?<=\/).+?(?=\/|$)");
        Regex partWithParamsReg = new Regex(@"(.+)(\?)(.+)(?=\/|$)");
        Regex extraParamsReg = new Regex(@"([^=&]+)(=)([^=&]+)");

        XmlElement parameters;
        XmlElement uri;
        XmlElement urlAddress;
        XmlElement urlAddresses;
        XmlDocument xDocument;

        private string resultFile = Directory.GetCurrentDirectory() + "URLAddresses.xml";
        private string errorsFile = Directory.GetCurrentDirectory() + "Errors.log";

        public UrlExporter()
        {
            xDocument = new XmlDocument();
            urlAddresses = xDocument.CreateElement("urlAddresses");
        }

        private void NewHost(string hostValue, ref bool firstTime)
        {
            XmlElement host = xDocument.CreateElement("host");
            hostValue = hostValue.Remove(0, 1);
            host.SetAttribute("name", hostValue);
            urlAddress.AppendChild(host);
            firstTime = false;
        }

        private void NewSegment(string segmentValue, ref bool firstUri)
        {
            if (firstUri)
            {
                uri = xDocument.CreateElement("uri");
                firstUri = false;
            }

            XmlElement segment = xDocument.CreateElement("segment");
            segment.InnerText = segmentValue;
            uri.AppendChild(segment);
            urlAddress.AppendChild(uri);
        }

        private void NewParam(string paramKey, string paramValue, ref bool firstParameters)
        {
            if (firstParameters)
            {
                parameters = xDocument.CreateElement("parameters");
                firstParameters = false;
            }

            XmlElement parametr = xDocument.CreateElement("parametr");
            parametr.SetAttribute("key", paramKey);
            parametr.SetAttribute("value", paramValue);
            parameters.AppendChild(parametr);
            urlAddress.AppendChild(parameters);
        }

        public void Export(string file)
        {

            string fileDataString = "";
            try
            {
                using (StreamReader stream = new StreamReader(file))
                {
                    while (stream.Peek() != -1)
                    {
                        fileDataString = stream.ReadLine();
                        if (urlAddressReg.IsMatch(fileDataString))
                        {
                            urlAddress = xDocument.CreateElement("urlAddress");

                            bool firstParameters = true;
                            bool firstTime = true;
                            bool firstUri = true;

                            foreach (Match foundPartsWithoutParams in partWithoutParamsReg.Matches(fileDataString))
                            {
                                if (firstTime)
                                {
                                    NewHost(foundPartsWithoutParams.ToString(), ref firstTime);
                                }
                                else
                                {
                                    if (!partWithParamsReg.IsMatch(foundPartsWithoutParams.ToString()))
                                    {
                                        NewSegment(foundPartsWithoutParams.ToString(), ref firstUri);
                                    }
                                    else
                                    {
                                        foreach (Match foundPartsWithParams in partWithParamsReg.Matches(foundPartsWithoutParams.ToString()))
                                        {
                                            NewSegment(foundPartsWithParams.Groups[1].ToString(), ref firstUri);
                                            foreach (Match foundExtraParams in extraParamsReg.Matches(foundPartsWithParams.Groups[3].Value))
                                            {
                                                NewParam(foundExtraParams.Groups[1].ToString(), foundExtraParams.Groups[3].ToString(), ref firstParameters);
                                            }
                                        }
                                    }
                                }
                            }
                            urlAddresses.AppendChild(urlAddress);
                        }
                        else
                        {
                            try {using (StreamWriter sw = new StreamWriter(File.Open(errorsFile, FileMode.Append))){sw.WriteLine("Couldn't export data");}}
                            catch (IOException)
                            {
                                throw new IOException();
                            }
                        }
                    }

                    xDocument.AppendChild(urlAddresses);
                    XmlSerializer serializer = new XmlSerializer(typeof(XmlElement));

                    try {using (TextWriter writer = new StreamWriter(resultFile)){serializer.Serialize(writer, xDocument);}}
                    catch (IOException)
                    {
                        throw new IOException();
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }
    }
}
