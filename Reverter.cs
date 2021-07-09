using System;
using System.Text; // For StringBuilder object

namespace WorkArea {
    public class Reverter {
        static void Main(string[] args) {
            string text = "Revert me!";
            string reversed = Reverse(text);
            System.Console.WriteLine($"\nBefore: {text}\nAfter: {reversed}");
        }
        static string Reverse(string text) {
            int text_length = text.Length;
            char[] text_array = text.ToCharArray(); // Convert string to character array 
            char[] reversed_array = new char[text_length]; // New character array with the length of the first array
            StringBuilder reverted = new StringBuilder("", text_length); // Creates new blank string

            int count = text.Length - 1;
            while (count >= 0) {    
                reverted.Append(text_array[count]); // Appends each character from last to first.
                --count;
            }
            return reverted.ToString(); // Returns StringBuilder object as string
        }
    }
}

