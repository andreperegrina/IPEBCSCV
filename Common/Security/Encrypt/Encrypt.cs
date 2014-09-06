using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Common.Security.Encrypt
{
    public class Encrypt
    {
        public string EncodePassword(string password)
        {

            byte[] original_bytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] encoded_bytes = new MD5CryptoServiceProvider().ComputeHash(original_bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < encoded_bytes.Length; i++)
            {
                result.Append(encoded_bytes[i].ToString("x2"));
            }
            return result.ToString();

            //Declarations

            //Byte[] originalBytes;
            //Byte[] encodedBytes;
            //MD5 md5;

            ////Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            //md5 = new MD5CryptoServiceProvider();
            //originalBytes = ASCIIEncoding.Default.GetBytes(password);
            //encodedBytes = md5.ComputeHash(originalBytes);

            ////Convert encoded bytes back to a 'readable' string
            //return BitConverter.ToString(encodedBytes);
        }
    }
}
