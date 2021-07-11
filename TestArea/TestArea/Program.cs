using System;
using System.Collections.Generic;
namespace TestArea
{
    class Program
    {
        static void Main(string[] args)
        {
            string operatorChoice = Operation();
            if (operatorChoice == "Exit") { System.Environment.Exit(0); }
            else if (operatorChoice == "Addition") { Addition(); }
            else if (operatorChoice == "Subtraction") { Subtraction(); }
        }

        static string Operation()
        {
            string str_choice;
            Dictionary<int, string> operators = new Dictionary<int, string>()
            {
                {0, "Exit"},
                {1, "Addition"},
                {2, "Subtraction"},
                {3, "Multiplication"},
                {4, "Division"}
            };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n[ Operation Selection ]\n");
                foreach (KeyValuePair<int, string> kvp in operators)
                {
                    Console.WriteLine($"[{kvp.Key}] {kvp.Value}");
                }
                try
                {
                    Console.Write("\nEnter choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    str_choice = operators[choice];
                    break;
                }
                catch
                {
                    Console.WriteLine("\n\nInvalid data, need numeric input within the menu scope..");
                    Console.ReadKey();
                    continue;
                }
            }
            return str_choice;
        }

        static void Addition()
        {
            int num1; int num2;
            int result;
            int score = 0;
            Random number = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n[ Addition ]\nScore: {score}");

                num1 = number.Next(10, 1000);
                num2 = number.Next(10, 1000);
                result = num1 + num2;

                string question = $"{num1} + {num2} = ";

                Console.Write(question);
                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == result)
                {
                    Console.WriteLine("\nCorrect!");
                    score++;
                    continue;
                }
                else
                {
                    Console.WriteLine("\nIncorrect!");
                    break;
                }
            }
        }

        static void Subtraction()
        {
            int num1; int num2;
            int result;
            Random number = new Random();

            num1 = number.Next(10, 1000);
            num2 = number.Next(10, 1000);
            result = num1 - num2;

            string question = $"\n{num1} - {num2} = ";

            Console.Write(question);
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == result)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }
    }
}
