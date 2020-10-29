using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        public static void Main()
        {
            CaesarCipher cipher = new CaesarCipher();
            UserInputHandler inputHandler = new UserInputHandler();

            // Get text to encrypt from user input
            Console.WriteLine("Write text below you want to encrypt:");
            string text = inputHandler.GetTextFromUser(Console.In);
            if (text == null)
            {
                Console.WriteLine("Input is invalid");
                Environment.Exit(0);
            }

            // Get shift for encryption from user input
            Console.WriteLine("Write shift for encryption algorithm");
            int shift = inputHandler.GetShiftFromUser(Console.In);
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
