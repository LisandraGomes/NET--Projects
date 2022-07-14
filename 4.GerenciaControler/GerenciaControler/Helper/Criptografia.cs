using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaControler.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string senha)
        {
            var hash = SHA1.Create();
            var Encoding = new ASCIIEncoding();
            var array = Encoding.GetBytes(senha);

            array = hash.ComputeHash(array);

            var str = new StringBuilder();

            foreach(var a in array)
            {
                str.Append(a.ToString("x2"));
            }

            return str.ToString();
        }
    }
}
