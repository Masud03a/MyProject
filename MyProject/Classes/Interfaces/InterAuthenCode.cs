using System;

namespace MyProject
{
    public interface IAuthenCode
    {
       bool Login (string _table_name);
       bool PasswordVerification();
       bool IsPreviouslyCreated(bool _admin);
       bool RegistrateAccount(string _table_name);
    }
}