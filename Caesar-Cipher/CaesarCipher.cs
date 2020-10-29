using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Caesar_Cipher
{
    public class CaesarCipher
    {
        public string Encrypt(string plainText, int shift)
        {
            string cipherText = string.Empty;

            foreach (var c in plainText)
            {
                char? changedChar = CipherAlgorithm(c, shift);
                if (changedChar == null)
                    return null;
                cipherText += changedChar;
            }
            return cipherText;
        }

        public static char? CipherAlgorithm(char c, int shift)
        {
            if (!char.IsLetter(c) && c != 32)
                return null;
            if (c == 32)
                return c;
            char offset = char.IsUpper(c) ? 'A' : 'a';
            if (shift < 0)
                return (char)((c + (26 + shift) - offset) % 26 + offset);
            return (char)((c + shift - offset) % 26 + offset);
        }

        public string Decrypt(string encryptedText, int shift)
        {
            return Encrypt(encryptedText, 26 - shift);
        }
    }
}