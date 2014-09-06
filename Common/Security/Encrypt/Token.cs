using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Security.Encrypt
{
    public class Token
    {
        public String GetToken(int digito)
        {
            String token = "";
            Random random = new Random();
            int digitos = digito;
            
            if (digito > 10)
                digitos = 10;

            for (int i = 0; i < digitos; ++i)
            {
                int valor = random.Next(9);
                token = token + valor;
            }

            return token;
        }

    }
}
