using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Caesar_Cipher
{
    public class UserInputHandler
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
    }
}
