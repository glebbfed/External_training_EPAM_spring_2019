namespace DAL.Interface.Interfaces
{
    public interface IStorage
    {
        void AddAccount(DALAccount account);
        void RemoveAccount(DALAccount account);
        void DisplayStorage();
        void SaveToFile();
        void LoadFromFile();

    }
}
