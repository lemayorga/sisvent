using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Services.Entity.Helpers
{
    public class CryptString
    {
        #region Encriptacion 1

        private static string keyString = "wpwEqQn69uMosHTn7KCSaAdK6pc22zqf";

        public static string EncryptString(string text)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string DecryptString(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        #endregion

        #region Encriptacion 2

        public static string GeneratePassword(int length = 10) //length of salt    
        {  
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";  
            var randNum = new Random();  
            var chars = new char[length];  
            var allowedCharCount = allowedChars.Length;  
            for (var i = 0; i <= length - 1; i++)  
            {  
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];  
            }  
            return new string(chars);  
        }

        public static string EncodePassword(string pass, string salt) //encrypt password    
        {  
            byte[] bytes = Encoding.Unicode.GetBytes(pass);  
            byte[] src = Encoding.Unicode.GetBytes(salt);  
            byte[] dst = new byte[src.Length + bytes.Length];  
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);  
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);  
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");  
            byte[] inArray = algorithm.ComputeHash(dst);  
            return EncodePasswordMd5(Convert.ToBase64String(inArray));  
        }

        public static string EncodePasswordMd5(string pass) //Encrypt using MD5    
        {  
            Byte[] originalBytes;  
            Byte[] encodedBytes;  
            MD5 md5;  
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)    
            md5 = new MD5CryptoServiceProvider();  
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);  
            encodedBytes = md5.ComputeHash(originalBytes);  
            //Convert encoded bytes back to a 'readable' string    
            return BitConverter.ToString(encodedBytes);  
        }

        public static string base64Encode(string sData) // Encode    
        {  
            try  
            {  
                byte[] encData_byte = new byte[sData.Length];  
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);  
                string encodedData = Convert.ToBase64String(encData_byte);  
                return encodedData;  
            }  
            catch (Exception ex)  
            {  
                throw new Exception("Error in base64Encode" + ex.Message);  
            }  
        }  
        public static string base64Decode(string sData) //Decode    
        {  
            try  
            {  
                var encoder = new System.Text.UTF8Encoding();  
                System.Text.Decoder utf8Decode = encoder.GetDecoder();  
                byte[] todecodeByte = Convert.FromBase64String(sData);  
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);  
                char[] decodedChar = new char[charCount];  
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);  
                string result = new String(decodedChar);  
                return result;  
            }  
            catch (Exception ex)  
            {  
                throw new Exception("Error in base64Decode" + ex.Message);  
            }  
        }      
        #endregion  
    }
}