using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SRM_System.LogInEmoloyee
{
    public class EmployeePassword
    {
        byte[] PasswordSource;
        byte[] tmpPassword;
        public byte[] OnePasswordHash(string password)
        {
            PasswordSource = ASCIIEncoding.ASCII.GetBytes(password);
            return tmpPassword = new MD5CryptoServiceProvider().ComputeHash(PasswordSource);
        }
        public string ByteArrayToString(byte[] HashArrInput)
        {
            int i;
            StringBuilder HashString = new StringBuilder(HashArrInput.Length);
            for (i = 0; i < HashArrInput.Length; i++)
            {
                HashString.Append(HashArrInput[i].ToString("X2"));
            }
            return HashString.ToString();
        }
    }
}
