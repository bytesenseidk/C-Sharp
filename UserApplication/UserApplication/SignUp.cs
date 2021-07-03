using System;
using System.IO;


namespace UserApplication
{
    class SignUp
    {
        public string username;
        public string password;
        public string filePath = Environment.CurrentDirectory.Replace(@"\bin\Debug\net5.0", @"\Users.txt");

        public void AddUser()
        {
            using (StreamWriter userFile = File.AppendText(filePath))
            {
                userFile.WriteLine($"{username}; {password}");
                userFile.Close();
            }
        }
    }
}
