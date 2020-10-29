using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Caesar_Cipher.UnitTests
{
    [TestClass]
    public class CaesarCipherTests
    {
        [TestMethod]
        public void EncryptTest_WhenGettingUpperLetters()
        {
            // Arrange
            const string text = "ABC";
            const int shift = 2;
            const string expected = "CDE";
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.AreEqual(expected, encryptedText);
        }

        [TestMethod]
        public void EncryptTest_WhenGettingLowerLetters()
        {
            // Arrange
            const string text = "abc";
            const int shift = 2;
            const string expected = "cde";
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.AreEqual(expected, encryptedText);
        }

        [TestMethod]
        public void EncryptTest_WhenGettingLowerAndUpperLetters()
        {
            // Arrange
            const string text = "AbCd";
            const int shift = 2;
            const string expected = "CdEf";
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.AreEqual(expected, encryptedText);
        }

        [TestMethod]
        public void EncryptTest_WhenInInputIsDigit()
        {
            // Arrange
            const string text = "Ab1d";
            const int shift = 2;
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.IsNull(encryptedText);
        }

        [TestMethod]
        public void EncryptTest_WhenInInputIsSpace()
        {
            // Arrange
            const string text = "Ab Cd";
            const int shift = 2;
            const string expected = "Cd Ef";
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.AreEqual(expected, encryptedText);
        }

        [TestMethod]
        public void EncryptTest_WhenResultIsWrong()
        {
            // Arrange
            const string text = "Ab Cd";
            const int shift = 2;
            const string expected = "aa aa";
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.AreNotEqual(expected, encryptedText);
        }

        [TestMethod]
        public void EncryptTest_WhenShiftIsNegative()
        {
            // Arrange
            const string text = "ABC";
            const int shift = -1;
            const string expected = "ZAB";
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.AreEqual(expected, encryptedText);
        }

        [TestMethod]
        public void DecryptTest_WithValidData()
        {
            // Arrange
            const string text = "CC dd";
            const int shift = 2;
            const string expected = "AA bb";
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Decrypt(text, shift);
            // Assert
            Assert.AreEqual(expected, encryptedText);
        }

        [TestMethod]
        public void DecryptTest_WithInvalidData()
        {
            // Arrange
            const string text = "CC dd12";
            const int shift = 2;
            var cipher = DefaultCaesarCipher();
            // Act
            string encryptedText = cipher.Decrypt(text, shift);
            // Assert
            Assert.IsNull(encryptedText);
        }

        private CaesarCipher DefaultCaesarCipher()
        {
            return new CaesarCipher();
        }
    }
}