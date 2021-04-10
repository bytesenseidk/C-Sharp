using System;

namespace CSharp {
    class Comparison {
        static void Main(string[] args) {
            string string_1 = "Hello!";
            string string_2 = "Hello!";
            string string_3 = "coding";
            bool result_1 = Compare(string_1, string_2);
            bool result_2 = Compare(string_1, string_3);
            System.Console.WriteLine($"Is '{string_1}' equal to '{string_2}': {result_1}");
            System.Console.WriteLine($"Is '{string_1}' equal to '{string_3}': {result_2}");
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

