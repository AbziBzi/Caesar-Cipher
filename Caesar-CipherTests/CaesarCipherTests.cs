using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Caesar_Cipher.UnitTests
{
    [TestClass]
    public class CaesarCipherTests
    {
        [TestMethod]
        public void GetTextFromUserTest_WithValidInput()
        {
            // Arrange
            const string input = "ABC";
            var stringReader = new StringReader(input);
            const string expected = "ABC";
            CaesarCipher cipher = new CaesarCipher();
            
            // Act 
            string gottenValue = cipher.GetTextFromUser(stringReader);

            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetTextFromUserTest_WhenInputIsEmptyString()
        {
            // Arrange
            const string input = "";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();

            // Act 
            string gottenValue = cipher.GetTextFromUser(stringReader);

            // Assert
            Assert.IsNull(gottenValue);
        }

        [TestMethod]
        public void GetTextFromUserTest_WithNumbersInInput()
        {
            // Arrange
            const string input = "ABC1";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();

            // Act 
            string gottenValue = cipher.GetTextFromUser(stringReader);

            // Assert
            Assert.IsNull(gottenValue);
        }

        [TestMethod]
        public void GetTextFromUserTest_WithSpaceInInput()
        {
            // Arrange
            const string input = "ABC DEF";
            var stringReader = new StringReader(input);
            const string expected = "ABC DEF";
            CaesarCipher cipher = new CaesarCipher();

            // Act 
            string gottenValue = cipher.GetTextFromUser(stringReader);

            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetTextFromUserTest_WhenInputIsNotEqual()
        {
            // Arrange
            const string input = "ABC DEF";
            var stringReader = new StringReader(input);
            const string expected = "DEF ABC";
            CaesarCipher cipher = new CaesarCipher();

            // Act 
            string gottenValue = cipher.GetTextFromUser(stringReader);

            // Assert
            Assert.AreNotEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WithValidInput()
        {
            // Arrange
            const string input = "1";
            var stringReader = new StringReader(input);
            const int expected = 1;
            CaesarCipher cipher = new CaesarCipher();
            
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);

            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WithEmptyInput()
        {
            // Arrange
            const string input = "";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            const int expected = 0;
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);

        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenInputIsWithFraction()
        {
            // Arrange
            const string input = "1.2";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            const int expected = 0;
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenInputIsNotEqual()
        {
            // Arrange
            const string input = "1";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            const int expected = 2;
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);

            // Assert
            Assert.AreNotEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenInputIsNegative()
        {
            // Arrange
            const string input = "-1";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            const int expected = -1;
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);

            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenIsOnlyDash()
        {
            // Arrange
            const string input = "-";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            const int expected = 0;
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenSpaceAtTheEndInput()
        {
            // Arrange
            const string input = "12 ";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            const int expected = 12;
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);
            //Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenSpaceInBetween()
        {
            // Arrange
            const string input = "12 1";
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            const int expected = 0;
            // Act
            int gottenValue = cipher.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }
        [TestMethod]
        public void EncryptTest_WhenGettingUpperLetters()
        {
            // Arrange
            const string text = "ABC";
            const int shift = 2;
            const string expected = "CDE";
            CaesarCipher cipher = new CaesarCipher();
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
            CaesarCipher cipher = new CaesarCipher();
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
            CaesarCipher cipher = new CaesarCipher();
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
            CaesarCipher cipher = new CaesarCipher();
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
            CaesarCipher cipher = new CaesarCipher();
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
            CaesarCipher cipher = new CaesarCipher();
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
            const int shift = -2;
            const string expected = "ZAB";
            CaesarCipher cipher = new CaesarCipher();
            // Act
            string encryptedText = cipher.Encrypt(text, shift);
            // Assert
            Assert.AreNotEqual(expected, encryptedText);
        }
        [TestMethod]
        public void DecryptTest_WithValidData()
        {
            // Arrange
            const string text = "CC dd";
            const int shift = 2;
            const string expected = "AA bb";
            CaesarCipher cipher = new CaesarCipher();
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
            CaesarCipher cipher = new CaesarCipher();
            // Act
            string encryptedText = cipher.Decrypt(text, shift);
            // Assert
            Assert.IsNull(encryptedText);
        }
    }
}