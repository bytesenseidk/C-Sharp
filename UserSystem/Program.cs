using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace UserSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Validate tmp = new Validate();
            tmp.saveData();
        }
    }
    
    public class Validate
    {
        public bool validateData(string input, string field)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>(){
                {"username",    @"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$"},
                {"password",    @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"},
                {"email",       @"^[^@\s]+@[^@\s]+\.[^@\s]+$"}
            };
            Regex rgex = new Regex(fields[field]);
            if (rgex.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void saveData()
        {
            string cs = @"server=localhost;userid=dbuser=password=s$cret;database=testdb";
            using var connection = new MySqlConnection(cs);
            connection.Open();
            System.Console.WriteLine(connection.ServerVersion);
        }

        public Dictionary<string,string> getData()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>(){
                {"username",    ""},
                {"password",    ""},
                {"email",       ""}
            };
            foreach (string field in fields.Keys)
            {
                bool repeat = true;
                while (repeat)
                {
                    System.Console.Write($"Please enter a {field} >> ");
                    string? input = Console.ReadLine();
                    if (validateData(input, field))
                    {
                        System.Console.WriteLine("\nValid!");
                        fields[field] = input;
                        repeat = false;
                    }
                    else
                    {
                        System.Console.WriteLine("\nInvalid!");
                    }
                }                
            }
            return fields;
        }
    }

    public class Database
    {

    } 
}