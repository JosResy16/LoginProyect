using System.Security.Cryptography;
using System.Text;

namespace LoginProyect.Resources
{
    public class Utilities
    {
        public static string EncriptarClave(string enclave)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;

                byte[] result = hash.ComputeHash(encoding.GetBytes(enclave));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
