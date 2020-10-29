# Caesar-Cipher

In cryptography, a Caesar cipher is one of the simplest and most widely known encryption techniques. It is a type of substitution cipher in which each letter in the plaintext is replaced by a letter some fixed number of positions down the alphabet. For example, with a left shift of 3, D would be replaced by A, E would become B, and so on.

### How program works

First, the program asks the user to enter the text he wants to encrypt
Then the user has to enter the key by which the letters will be shifted.
After receiving the input, the program performs the encryption. 
The encrypted text is printed on the screen. 
The program then decrypts the previously encrypted text, which is also printed on the screen

### Caesar cipher example 
- When shift is 2
  - Plain text : Aa Bb Yy Zz
  - Encrypted text : Cc Dd Aa Bb
- Also works when shift is negative. In example -2
  - Plain text : Aa Bb Yy Zz
  - Encrypted text : Yy Zz Ww Xx
### Project structure

The program has three classes: 
- Program - is responsible for running program. The only method is Main()
- UserInputHandler - which is responsible for user input handling and has following methods:
  - GetTextFromUser() - this method handles user input that will be encrypted
  - GetShiftFromUser() - this method also handles user input, but this one is for shift/key
- CaesarCipher - which is responsible for cipher logic and has methods:
  - Encrypt() - method that handles encryption
  - CipherAlgorithm() - in this method is all algorithm logic. There characters are shifted by the given number
  - Decrypt() - method that handles decryption

Project also contains unit tests. Unit tests are written using MSTest framework.
Unit test coverage for CaesarCipher class is 57%. The only method that is not tested is Main(). Coverage of other methods is 100%