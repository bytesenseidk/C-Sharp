using System;

namespace CSharp {
    class Comparison {
        static void Main(string[] args) {
            string string_1 =  "Hello!";
            string string_2 =  "Hello!";
            bool result = Compare(string_1, string_2);
            System.Console.WriteLine(result);
        }
        static bool Compare(string string_1, string string_2) {
            int counter = 0;
            bool validation = false;
            if (string_1.Length != string_2.Length) {
                validation = false;
            }
            else {
                foreach (char value in string_1) {
                    if (value == string_2[counter]) {
                        validation = true;
                    }
                    else {
                        validation = false;
                        return validation;
                    }
                counter++;
                }
            }
            return validation;
        }
    }
}