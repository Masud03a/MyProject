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

namespace MyProject
{
    public class HashCode : InterHashCode
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
            var _hashCode = _md5.ComputeHash(Encoding.UTF8.GetBytes(inputedData));
             _results = Convert.ToBase64String(_hashCode);
            return _results;
        }    
    }
}
