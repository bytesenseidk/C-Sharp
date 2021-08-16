using System.Text.RegularExpressions;

namespace PWATraining.Modules;


public class UserCreation
{
    public string? Username { get; }
    public string? Password { get; }

    public UserCreation(string username, string password)
    {
        Username = username;
        Password = password;
    }

    readonly string usersPath = Environment.CurrentDirectory.Replace(@"bin\Debug\net6.0", @"\Users.txt");

    public string AddUser()
    {
        bool usernameVal = UsernameValidation();
        bool passwordVal = PasswordValidation();

        if (usernameVal && passwordVal)
        {
            UserAdding();
            return "Sign Up Successful!";
        }
        else
        {
            return "Sign Up Unsuccessful!";
        }
    }
    public bool UsernameValidation()
    {
        Regex invalids = new(@"^[0-9]");
        if (!string.IsNullOrEmpty(Username))
		{
            MatchCollection matchDetections = invalids.Matches(Username);
            if (matchDetections.Count != 0)
            {
                return false;
            }
            else
            {
                using (StreamReader userFile = new StreamReader(usersPath))
                {
                    string[] users = userFile.ReadToEnd().Split('\n');
                    foreach (string userIns in users)
                    {
                        if (userIns.Contains(Username))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        } 
        else 
        { 
            return false; 
        }
    }

    private bool PasswordValidation()
    {
        if (!string.IsNullOrEmpty(Password))
        {
            if (Password.Length < 8)
            {
                Console.WriteLine("Password length should be over 8 characters long...");
                return false;
            }
            else if (Password.Equals(Username))
            {
                Console.WriteLine("Password and username should not be the same...");
                return false;
            }
            return true;
        } 
        else 
        { 
            return false; 
        }

    }
    private void UserAdding()
    {
        using (StreamWriter userFile = File.AppendText(usersPath))
        {
            string user = $"{Username}; {Password}";
            userFile.WriteLine(user);
        }
    }
}
