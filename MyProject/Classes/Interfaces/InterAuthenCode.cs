namespace MyProject
{
    public interface InterAuthenCode
    {
        bool Login(string _table_name);
        bool PasswordVerification();
        bool isPreviouslyCreated(bool _admin);
        bool RegistrateAccount(string _table_name);
    }
}