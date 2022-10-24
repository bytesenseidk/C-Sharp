using System;
using System.Text.RegularExpressions;

namespace UserSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string input = "hello";
            validate tmp = new validate(input);
            
            
        }

        public bool validate(string input)
        {
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
/*
        public static bool validateInput(string input, string field)
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
        */
    }
}