using System;
using System.IO;
using System.Linq;

namespace User_System
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}