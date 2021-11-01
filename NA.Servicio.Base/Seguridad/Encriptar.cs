using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.Base.Seguridad
{
    public class Encriptar
    {
        private readonly string hash = @"foxle@rn";

        public string EncriptarPassword(string pass)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(pass);
            string passEncriptada = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    passEncriptada = Convert.ToBase64String(results);
                }
            }

            return passEncriptada;
        }

        public string DesEncriptarPassword(string pass)
        {
            byte[] data = Convert.FromBase64String(pass);
            string passDesEncriptada = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    passDesEncriptada = UTF8Encoding.UTF8.GetString(results);
                }
            }

            return passDesEncriptada;
        }
    }
}
