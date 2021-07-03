using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace User_System
{
    public class Signup
    {
        public string username;
        public string password;
        public string filePath = Environment.CurrentDirectory.Replace(@"\bin\Debug\netcoreapp3.1", @"\Users.txt");

        public bool UsernameValidation()
        {
            Regex invalids = new Regex(@"^[0-9]"); // Regular expression for numbers
            MatchCollection matchDetections = invalids.Matches(username); // Checks for leading digits in the username
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
            return true;
        }
        public bool UserValidation()
        {
            bool username = UsernameValidation();
            bool password = PasswordValidation();
            return username && password;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Signup signup = new Signup();
            signup.username = "Lars";
            signup.password = "Larssdfsdfsdf";
            Console.WriteLine(signup.UserValidation());
        }
    }
}


 /*           
            char valg = WelcMenu();
            Console.WriteLine(valg);
        }
           
                    static char WelcMenu()
                    {
                        char[] choices = { 'l', 's', 'q' }; // Array of valid keystrokes
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("[ User System ]\n");
                            Console.WriteLine("[L] Login");
                            Console.WriteLine("[S] Sign Up");
                            Console.WriteLine("[Q] Quit\n");
                            Console.Write("  >> ");
                            char choice = Console.ReadKey().KeyChar; // Assign keystroke to variable
                            Console.WriteLine();
                            if (choices.Contains(choice))
                            {
                                // Validates if keystroke is present in the choices array
                                return choice;
                            }
                            else
                            {
                                // Restarts loop if invalid key was given
                                Console.WriteLine("\n\nInvalid key!\n");
                                Console.Write("Press Enter to continue...");
                                Console.ReadKey();
                                continue;
                            }
                        }
                    }
                    static void SignUp()
                    {
                        string user;
                        string path = Environment.CurrentDirectory; // Assigns path of program to variable
                        string user_file = path.Replace(@"\bin\Debug\netcoreapp3.1", @"\Users.txt");
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("[ Sign Up ]\n");
                            while (true)
                            {
                                bool restart = false;
                                try
                                {
                                    Regex invalids = new Regex(@"^\d$"); // Regular expression for numbers
                                    Console.Write("Enter username  >> ");
                                    string username = Console.ReadLine();
                                    MatchCollection matchDetections = invalids.Matches(username); // Checks for leading digits in the username
                                    if (matchDetections.Count > 0)
                                    {
                                        Console.WriteLine("\n\nInvalid username, it cannot start with digits...\n");
                                        Console.Write("Press Enter to continue...");
                                        Console.ReadKey();
                                        continue;
                                    }
                                    else
                                    {
                                        using (StreamReader userFile = new StreamReader(user_file))
                                        {

                                            string[] users = userFile.ReadToEnd().Split('\n');
                                            foreach (string userIns in users)
                                            {
                                                if (userIns.Contains(username)) 
                                                {
                                                    restart = true;
                                                    Console.WriteLine("\n\nUsername already in use...\n");
                                                    Console.Write("Press Enter to continue...");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    restart = false;
                                                    user = $"{username};";
                                                }
                                            }
                                            userFile.Close();
                                        }
                                        if (restart == true)
                                        {
                                            continue;
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("");
                                }

                            }
                        }
                         Instans af StreamWriter der bruges til at skrive til brugere.txt
                        using (StreamWriter fil = File.AppendText(bruger_fil))
                        {
                            fil.WriteLine(person);
                            // Lukker instans af fil, dette gør det muligt at tilgå tekstfilen igen fra en anden metode
                            fil.Close();
                        }
                        Console.WriteLine("\n\nBruger tilføjet\n");
                        Console.Write("Tryk tast for at fortsætte");
                        Console.ReadKey();
                        Menu();
                    } 
 */