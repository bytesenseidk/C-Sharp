using System;
using System.IO;
using System.Text.RegularExpressions;

namespace UserApplication
{
    class Validator
    {
        public string username;
        public string password;
        public string filePath = Environment.CurrentDirectory.Replace(@"\bin\Debug\net5.0", @"\Users.txt");

        public bool Validate()
        {
            if (UsernameValidation() && PasswordValidation())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UsernameValidation()
        {
            Regex invalids = new Regex(@"^[0-9]"); // Regular expression for leading numbers
            MatchCollection matchDetections = invalids.Matches(username);
            if (matchDetections.Count != 0)
            {
                return false;
            }
            else
            {
                using (StreamReader userFile = new StreamReader(filePath))
                {
                    string[] users = userFile.ReadToEnd().Split('\n');
                    foreach (string userIns in users)
                    {
                        if (userIns.Contains(username))
                        {
                            userFile.Close();
                            return false;
                        }
                    }
                    userFile.Close();
                }
            }
            return true;
        }
        public bool PasswordValidation()
        {
            if (password.Length < 8)
            {
                Console.WriteLine("\n\nPassword length should be over 8 characters long...\n");
                return false;
            }
            else if (password == username)
            {
                Console.WriteLine("\n\nPassword and username should not be the same...\n");
                return false;
            }
            return true;
        }
    }
}
