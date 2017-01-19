﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WcfService1
{
    public class Encrypt_decrypt
    {

        string PasswordHash = "!$%^*()@!asy";
        string SaltKey = "HMM;_;SALTaha@#";
        string VIKey = "@2JJhjD4emoka%!!!";

        //public string encrypt(string password)
        //{

        //    byte[] newcryptpassword;
        //    byte[] plaincryptpassword = System.Text.Encoding.UTF8.GetBytes(password);

        //    byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        //    var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
        //    var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //        {
        //            cryptoStream.Write(plaincryptpassword, 0, plaincryptpassword.Length);
        //            cryptoStream.FlushFinalBlock();
        //            newcryptpassword = memoryStream.ToArray();
        //            cryptoStream.Close();
        //        }
        //        memoryStream.Close();
        //    }

        //    return Convert.ToBase64String(newcryptpassword);
        //}

    
        public string decrypt(string cryptpassword)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cryptpassword);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }


        public bool Authentication(string encryptLogin, string encryptPassword)
        {
            try
            {
                string login = decrypt(encryptLogin);
                string password = decrypt(encryptPassword);

                Connection ConAuthentication = new Connection();
                DataSet veryfauthentication = ConAuthentication.sqldata("SELECT [Id], [login], [password], [date] FROM [dbo].[WCFaccount] where login = '" + login + "' and password  = '" + password + "' and [date] > GETDATE()");
                if (veryfauthentication.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

       
            
         


        }  
    }
}