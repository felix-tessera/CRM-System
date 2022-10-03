using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SRM_System.Models;

namespace SRM_System.RegisterLogic
{
    public class CheckAdminPassword
    {
        byte[] PasswordBaseSource;
        byte[] PasswordConfirmationSource;
        byte[] tmpPasswordBase;
        byte[] tmpPasswordConfirmation;

        public void RegistrationPasswordsHash(string PasswordBase, string PasswordConfirmation)
        {
            PasswordBaseSource = ASCIIEncoding.ASCII.GetBytes(PasswordBase);
            tmpPasswordBase = new MD5CryptoServiceProvider().ComputeHash(PasswordBaseSource);

            PasswordConfirmationSource = ASCIIEncoding.ASCII.GetBytes(PasswordConfirmation);
            tmpPasswordConfirmation = new MD5CryptoServiceProvider().ComputeHash(PasswordConfirmationSource);
        }

        public byte[] OnePasswordHash(string password)
        {
            PasswordBaseSource = ASCIIEncoding.ASCII.GetBytes(password);
            return tmpPasswordBase = new MD5CryptoServiceProvider().ComputeHash(PasswordBaseSource);
        }

        public static string ByteArrayToString(byte[] HashArrInput)
        {
            int i;
            StringBuilder HashString = new StringBuilder(HashArrInput.Length);
            for (i = 0; i < HashArrInput.Length; i++)
            {
                HashString.Append(HashArrInput[i].ToString("X2"));
            }
            return HashString.ToString();
        }
        public bool CheckMatchingPasswords()
        {
            bool bEqual = false;
            if (tmpPasswordConfirmation.Length == tmpPasswordBase.Length)
            {
                int i = 0;
                while ((i < tmpPasswordConfirmation.Length) && (tmpPasswordConfirmation[i] == tmpPasswordBase[i]))
                {
                    i += 1;
                }
                if (i == tmpPasswordConfirmation.Length)
                {
                    bEqual = true;
                }
            }

            if (bEqual)
            {
                Admin.password = ByteArrayToString(tmpPasswordBase);
                return true;
            }
            else
                return false;
        }
    }
}
