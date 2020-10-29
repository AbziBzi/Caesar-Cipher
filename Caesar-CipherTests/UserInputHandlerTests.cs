using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar_Cipher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Caesar_CipherTests
{
    [TestClass()]
    public class UserInputHandlerTests
    {
        [TestMethod]
        public void GetTextFromUserTest_WithValidInput()
        {
            // Arrange
            const string input = "ABC";
            var stringReader = new StringReader(input);
            const string expected = "ABC";
            var inputHandler = DefaultUserInputHandler();
            // Act 
            string gottenValue = inputHandler.GetTextFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetTextFromUserTest_WhenInputIsEmptyString()
        {
            // Arrange
            const string input = "";
            var stringReader = new StringReader(input);
            var inputHandler = DefaultUserInputHandler();
            // Act 
            string gottenValue = inputHandler.GetTextFromUser(stringReader);
            // Assert
            Assert.IsNull(gottenValue);
        }

        [TestMethod]
        public void GetTextFromUserTest_WithNumbersInInput()
        {
            // Arrange
            const string input = "ABC1";
            var stringReader = new StringReader(input);
            var inputHandler = DefaultUserInputHandler();
            // Act 
            string gottenValue = inputHandler.GetTextFromUser(stringReader);
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
            var inputHandler = DefaultUserInputHandler();
            // Act 
            string gottenValue = inputHandler.GetTextFromUser(stringReader);
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
            var inputHandler = DefaultUserInputHandler();
            // Act 
            string gottenValue = inputHandler.GetTextFromUser(stringReader);
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
            var inputHandler = new UserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WithEmptyInput()
        {
            // Arrange
            const string input = "";
            const int expected = 0;
            var stringReader = new StringReader(input);
            var inputHandler = DefaultUserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);

        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenInputIsWithFraction()
        {
            // Arrange
            const string input = "1.2";
            const int expected = 0;
            var stringReader = new StringReader(input);
            var inputHandler = DefaultUserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenInputIsNotEqual()
        {
            // Arrange
            const string input = "1";
            const int expected = 2;
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            var inputHandler = DefaultUserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreNotEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenInputIsNegative()
        {
            // Arrange
            const string input = "-1";
            const int expected = -1;
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            var inputHandler = DefaultUserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenIsOnlyDash()
        {
            // Arrange
            const string input = "-";
            const int expected = 0;
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            var inputHandler = DefaultUserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenSpaceAtTheEndInput()
        {
            // Arrange
            const string input = "12 ";
            const int expected = 12;
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            var inputHandler = DefaultUserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        [TestMethod]
        public void GetShiftFromUserTest_WhenSpaceInBetween()
        {
            // Arrange
            const string input = "12 1";
            const int expected = 0;
            var stringReader = new StringReader(input);
            CaesarCipher cipher = new CaesarCipher();
            var inputHandler = DefaultUserInputHandler();
            // Act 
            int gottenValue = inputHandler.GetShiftFromUser(stringReader);
            // Assert
            Assert.AreEqual(expected, gottenValue);
        }

        private UserInputHandler DefaultUserInputHandler()
        {
            return new UserInputHandler();
        }
    }
}