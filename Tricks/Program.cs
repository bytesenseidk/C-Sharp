using System;
using static System.Console;
/* Content:
- String formatting
- Platform Handling
*/

namespace Tricks
{
    class StringFormatting 
    {
        public string someStr = "C#";
        public int someInt = 7;
        public decimal someDec = 2.7M;
        public string someDate = DateTime.Now.ToString("dd':'MM':'yyyy");

        public void StandardFormat() 
        {
            WriteLine(
                format: "This is coded in:\t{0}\nHere is a currency:\t{1:C}\nToday's date:\t\t{2}",
                arg0: someStr,
                arg1: someInt * someDec,
                arg2: someDate);
        }
        public void InterpolatedFormat()
        {
            WriteLine($"This is coded in:\t{someStr}\nHere is a currency:\t{someInt * someDec:C}\nToday's date:\t\t{someDate}");
        }
    }

    class ExceptionHandling
    {
        public void TerminalFormatting()
        {
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            if (OperatingSystem.IsWindows())
            {
                try
                {
                    SetWindowSize(500, 500);
                    CursorSize = 50;
                }
                catch (ArgumentOutOfRangeException)
                {
                    WriteLine("Couldn't set window size because of the given size...\n");
                }
            }
            if (OperatingSystem.IsLinux())
            {
                try
                {
                    CursorSize = 50;
                }
                catch (ArgumentOutOfRangeException)
                {
                    WriteLine("Couldn't set cursor size because of the given size...\n");
                }
            }
        }
    }

    class GeneralSyntax
    {
        public void UnaryOperators()
        {
            int a = 4;
            int b = a++; // Increment a after assigning it
            int c = 3;
            int d = ++c; // Increment a before assigning it
            WriteLine("Variables: a=4, b=a++, c=3, d=++c");
            WriteLine($"Postfix: a = {a} : b = {b}\nPrefix:  c = {c} : d = {d}");
        }
        public void TryParseMethod()
        {
            int number;
            Write("Enter an integer: ");
            string input = ReadLine();

            if (int.TryParse(input, out number))
            {
                WriteLine($"Number entered: {number}");
            }
            else
            {
                WriteLine("Could not parse input...");
            }
        }
        public void TryCatchParse()
        {
            int number;
            Write("Enter an integer: ");
            string input = ReadLine();
            
            try
            {
                int parsedNum = int.Parse(input);
                WriteLine($"Entered an integer: {parsedNum}");
            }
            catch (Exception Ex)
            {
                WriteLine($"Error Type: \t{Ex.GetType()}\nError Message: \t{Ex.Message}");
            }
            finally
            {
                WriteLine("Done parsing...");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            void Arguments()
            {
                /* Print amount of arguments passed to the execution */
                WriteLine($"There are {args.Length} arguments passed to this program...");
                /* Print arguments */
                WriteLine();
                foreach (string arg in args)
                {
                    WriteLine(arg);
                }
            }
            
            void Formatting()
            {
                StringFormatting formatExample = new();
                formatExample.StandardFormat();
                WriteLine();
                formatExample.InterpolatedFormat();
            }
            
            void Platform()
            {
                ExceptionHandling handlingExample = new();
                // handlingExample.TerminalFormatting();
            }
            void Syntax()
            {
                GeneralSyntax syntax = new();
                syntax.UnaryOperators();
                WriteLine();
                // syntax.TryParseMethod();
                syntax.TryCatchParse();
            }
            
            Arguments();
            WriteLine();
            Formatting();
            WriteLine();
            Syntax();
            WriteLine();
            Platform();
        }
    }
}
