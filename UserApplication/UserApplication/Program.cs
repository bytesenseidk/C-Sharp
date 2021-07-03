using System;


namespace UserApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Validator validate = new Validator();
            SignUp signUp = new SignUp();
            validate.username = "hello";
            validate.password = "helloajlsd";
            signUp.username = "hello";
            signUp.password = "helloajlsd";
            bool validated = validate.Validate();
            if (validated)
            {
                Console.WriteLine(signUp.filePath); 
            }
            else
            {
                Console.WriteLine("Not validated");
            }
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