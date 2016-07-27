using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace HRM.Class
{
   public class Encryption
    {
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        private UTF8Encoding utf8 = new UTF8Encoding();

        private byte[] keyValue;
        private byte[] iVValue;

        /// <summary>
        /// Key to use during encryption and decryption
        /// </summary>
        /// <remarks>
        /// <example>
        /// byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        /// </example>
        /// </remarks>
        public byte[] Key
        {
            get { return keyValue; }
            set { keyValue = value; }
        }

        /// <summary>
        /// Initialization vetor to use during encryption and decryption
        /// </summary>
        /// <remarks>
        /// <example>
        /// byte[] iv = { 8, 7, 6, 5, 4, 3, 2, 1 };
        /// </example>
        /// </remarks>
        public byte[] iV
        {
            get { return iVValue; }
            set { iVValue = value; }
        }

        /// <summary>
        /// Constructor, allows the key and initialization vetor to be provided
        /// </summary>
        /// <param name="key"><see cref="Key"/></param>
        /// <param name="iV"><see cref="iV"/></param>
        public Encryption(byte[] key, byte[] iV)
        {
            this.keyValue = key;
            this.iVValue = iV;
        }

        /// <summary>
        /// Decrypt bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Decrypted data as bytes</returns>
        public byte[] Decrypt(byte[] bytes)
        {
            return Transform(bytes, des.CreateDecryptor(this.keyValue, this.iVValue));
        }

        /// <summary>
        /// Encrypt bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Encrypted data as bytes</returns>
        public byte[] Encrypt(byte[] bytes)
        {
            return Transform(bytes, des.CreateEncryptor(this.keyValue, this.iVValue));
        }

        /// <summary>
        /// Decrypt a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Decrypted data as string</returns>
        public string Decrypt(string text)
        {
            byte[] input = Convert.FromBase64String(text);
            byte[] output = Transform(input, des.CreateDecryptor(this.keyValue, this.iVValue));
            return utf8.GetString(output);
        }

        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Encrypted data as string</returns>
        public string Encrypt(string text)
        {
            byte[] input = utf8.GetBytes(text);
            byte[] output = Transform(input, des.CreateEncryptor(this.keyValue, this.iVValue));
            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// Encrypt or Decrypt bytes.
        /// </summary>
        /// <remarks>
        /// This is used by the public methods
        /// </remarks>
        /// <param name="input">Data to be encrypted/decrypted</param>
        /// <param name="cryptoTransform">
        /// <example>des.CreateEncryptor(this.keyValue, this.iVValue)</example>
        /// </param>
        /// <returns>Byte data containing result of opperation</returns>
        private byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
        {
            // Create the necessary streams
            MemoryStream memory = new MemoryStream();
            CryptoStream stream = new CryptoStream(memory, cryptoTransform, CryptoStreamMode.Write);

            // Transform the bytes as requesed
            stream.Write(input, 0, input.Length);
            stream.FlushFinalBlock();

            // Read the memory stream and convert it back into byte array
            memory.Position = 0;
            byte[] result = new byte[memory.Length];
            memory.Read(result, 0, result.Length);

            // Clean up
            memory.Close();
            stream.Close();

            // Return result
            return result;
        }
    }
}
