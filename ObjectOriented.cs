using System;
using System.Globalization;


// Object Oriented Example
namespace ObjectOriented
{
    public class Person
    {
        // Class parameters
        public string first;
        public string last;
        public Person(string firstName, string lastName)
        {
            // Constructor method
            this.first = firstName;
            this.last = lastName;
        }
        public string Fullname()
        {
            // Class method
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string firstName = textInfo.ToTitleCase(this.first);
            string lastName = textInfo.ToTitleCase(this.last);
            return $"{firstName} {lastName}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Class instance
            Person pers_1 = new("lars", "rosenkilde");
            Console.WriteLine(pers_1.Fullname());
        }
    }
}
