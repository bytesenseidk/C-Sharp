using System;
using System.Globalization;


// Object Oriented Example
namespace ObjectOriented
{
    public class PersonFirst
    {
        // Class parameters
        public string first;
        public string last;

        public PersonFirst(string firstName, string lastName)
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
            PersonFirst pers_1 = new PersonFirst("lars", "rosenkilde");
            Console.WriteLine(pers_1.Fullname());
        }
    }
}
