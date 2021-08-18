using System;
using static System.Console;
/* Content:
- String formatting

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
    class Program
    {
        static void Main(string[] args)
        {
            StringFormatting formatExample = new();
            formatExample.StandardFormat();
            System.Console.WriteLine();
            formatExample.InterpolatedFormat();
        }
    }
}
