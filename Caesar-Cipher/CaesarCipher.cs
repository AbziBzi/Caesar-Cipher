using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Caesar_Cipher
{
    public class CaesarCipher
    {
        public string GetTextFromUser(TextReader reader)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            string input = reader.ReadLine();
            if (string.IsNullOrEmpty(input))
                return null;
            if (!r.IsMatch(input))
                return null;
            return input;
        }

        public int GetShiftFromUser(TextReader reader)
        {
            string input = reader.ReadLine();
            if (!Int32.TryParse(input, out var shift))
                return 0;
            return shift;
        }

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
                return (char)((c + (26+shift) - offset) % 26 + offset);
            return (char)((c + shift - offset) % 26 + offset);
        }

        public string Decrypt(string encryptedText, int shift)
        {
            return Encrypt(encryptedText, 26 - shift);
        }

        public static void Main()
        {
            CaesarCipher cipher = new CaesarCipher();

            // Get text to encrypt from user input
            Console.WriteLine("Write text below you want to encrypt:");
            string text = cipher.GetTextFromUser(Console.In);
            if (text == null)
            {
                Console.WriteLine("Input is invalid");
                Environment.Exit(0);
            }

            // Get shift for encryption from user input
            Console.WriteLine("Write shift for encryption algorithm");
            int shift = cipher.GetShiftFromUser(Console.In);
            if (shift == 0)
            {
                Console.WriteLine("Input is invalid");
                Environment.Exit(0);
            }

            // Encrypt plain text
            string cipherText = cipher.Encrypt(text, shift);
            if (cipherText == null)
            {
                Console.WriteLine("Encryption has failed");
                Environment.Exit(0);
            }
            Console.WriteLine($"Cipher text:\n{cipherText}");

            // Decrypt cipher
            string decryptedText = cipher.Decrypt(cipherText, shift);
            if (decryptedText == null)
            {
                Console.WriteLine("Decryption has failed");
                Environment.Exit(0);
            }
            Console.WriteLine($"Decrypted text:\n{decryptedText}");
        }
    }
}