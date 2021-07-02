using System;

namespace CSharp 
{
    class Comparison
    {
        /* Compare two given strings*/ 
        static void Main(string[] args) 
        {
            string string_1 =  "Hello!";
            string string_2 =  "Hello!";
            bool result = Compare(string_1, string_2);
            System.Console.WriteLine(result);
        }
        static bool Compare(string string_1, string string_2) 
        {
            int counter = 0; // Index for second string
            bool validation = false; // Default string equality set to false
            if (string_1.Length != string_2.Length)
            {
                // If the given strings ain't of the same length, they cant be equal
                validation = false;
            }
            else 
            {
                foreach (char value in string_1)
                {
                    // Loops through each character and test if they match each other
                    if (value == string_2[counter]) 
                    {
                        validation = true;
                    }
                    else 
                    {
                        validation = false;
                        // If characters dont match, we end the loop and returns false
                        return validation;
                    }
                counter++; // If the character of each string match, we increase our counter and continue the loop
                }
            }
            return validation;
        }
    }
}

