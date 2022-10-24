/*
using System;
using System.Text.RegularExpressions;

namespace Account
{
    public static class AccountData
    {
        public static Dictionary<string, string> getData()
        {
            Dictionary<string, string> user = new Dictionary<string, string>();
            try
            {
                user.Add("first", "lars");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Username Already Exists");
            }
        }

        private bool validateInput(string input, string field)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("username", @"(^[aA-zZ])\w{4,23}");

            Regex re = new Regex(@"(^[aA-zZ])\w{4,23}");
            if (re.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
*/