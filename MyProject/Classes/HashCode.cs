/*
   Разработчик: Masud
   Дата: 21.04.2020
   Класс: HeshCode
   Файл: HeshCode.cs
   Описание: Генерация хеш-кода, по алгоритму MD5
*/

using System.Security.Cryptography;
using System;
using System.Text;

namespace Bank_Credit_Manager
{
    public class HashCode
    {
       private string inputedData = string.Empty; 
       public HashCode(string _data)
       {
           inputedData = _data;
       }


       public string Generate()
       {
           string _results = string.Empty;
           var _md5 = MD5.Create();
           var _heshCode = _md5.ComputeHash(Encoding.UTF8.GetBytes(inputedData));
           _results = Convert.ToBase64String(_heshCode);
           return _results;
       }
    }
}
