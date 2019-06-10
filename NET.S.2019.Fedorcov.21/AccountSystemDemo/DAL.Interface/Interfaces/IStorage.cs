namespace DAL.Interface.Interfaces
{
    public interface IStorage
    {
        void AddAccount(DALAccount account);
        void RemoveAccount(int id);
        void DisplayStorage();
        void SaveToFile();
        void LoadFromFile();
        void Clear();

    }
}
