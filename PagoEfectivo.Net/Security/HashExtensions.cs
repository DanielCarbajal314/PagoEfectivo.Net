using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Security
{
    public static class HashExtensions
    {
        internal static String ToSha256(this string value)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        public static string GetSignature(this string value, string key)
        {
            using (var hasher = new HMACSHA256(Encoding.ASCII.GetBytes(key)))
            {
                var hashsing = hasher.ComputeHash(Encoding.Default.GetBytes(value));
                return string.Join("", hashsing.ToList().Select(b => b.ToString("x2")).ToArray());
            }
        }
    }
}
