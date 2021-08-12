using System;
using static System.Console;


namespace BasicSyntax
{
    class Values
    {
        private string testString;
        private int testInt;
        private double testDouble;

        public string TestString
        {
            get { return testString;}
            set { testString = value ?? throw new ArgumentNullException("Missing a string"); } 
        }
        public int TestInt
        {
            get { return testInt; }
            set { testInt = value > 0 ? value : 1; }
        }
        public double TestDouble
        {
            get { return testDouble; }
            set { testDouble = value > 0 ? value : 1; }
        }
    }

    internal class StringFormatting : Values
    {
        public StringFormatting(string teststring, double testdouble, int testint)
        {
            TestString = teststring;
            TestDouble = testdouble;
            TestInt = testint;
        }
        public string DecimalLength()
        {
            return $"Decimal Length:\n{TestString}: {TestDouble} % {TestInt} = {TestInt % TestDouble:N2}";
        }
        public void Allignment()
        {
            WriteLine(
                "{0, -8} {1,7:N0}",
                arg0: "String",
                arg1: "Value");
            WriteLine(
                "{0, -8} {1,6:N0}",
                arg0: TestString,
                arg1: TestInt);
            WriteLine(
                "{0, -8} {1,6:N0}",
                arg0: TestString,
                arg1: TestDouble);
        }
        public void Keyinput()
        {
            Write("Press a key combination: ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine($"Key: {key.Key}, Char: {key.KeyChar}, Modifiers: {key.Modifiers}");
        }
        public void WindowCustomization()
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

    class Program
    {
        static void Main(string[] args)
        {
            string testString = "Formatted";
            double testDouble = 3.5;
            int testInt = 10;

            StringFormatting formatting = new(testString, testDouble, testInt);

            string StringInterpolationWdecimalLength = formatting.DecimalLength();

            formatting.WindowCustomization();
            WriteLine(StringInterpolationWdecimalLength);
            Write("\n");
            formatting.Allignment();
            Write("\n");
            formatting.Keyinput();
        }
    }
}
