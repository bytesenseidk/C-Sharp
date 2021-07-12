// TODO: Fix highscore & single digit input

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace TestArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation();
             
        }

        static void Operation()
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
            if (str_choice == "Exit") { System.Environment.Exit(0); }
            else if (str_choice == "Addition") { Addition(); }
            else if (str_choice == "Subtraction") { Subtraction(); }
            else if (str_choice == "Multiplication") { Multiplication(); }
            else if (str_choice == "Division") { Division(); }
        }
        // TODO
        /*
        static void Highscore(int score, string operation)
        {
            bool change = false;
            int lineIndex = 0;
            string highscorePath = Environment.CurrentDirectory.Replace(@"\bin\Debug\net5.0", @"\highscore.txt");
            try
            {
                using (StreamReader highscore = File.OpenText(highscorePath))
                {
                    string[] scores = highscore.ReadToEnd().Replace(" ", "").Split("\n");
                    foreach (string hScore in scores)
                    {
                        if (hScore.Contains(operation)) {
                            string[] curScore = hScore.Split(":");
                            if (Convert.ToInt32(curScore.Last()) < score)
                            {
                                change = true;
                                break;
                            }
                            else if (!hScore.Contains(operation))
                            {
                                change = true;
                            }
                        }
                        lineIndex++;
                    }
                }
                if (change == true)
                {
                    using (StreamWriter highscore = new StreamWriter(highscorePath))
                    {
                        string line = File.ReadLines(highscorePath).Skip(lineIndex).Take(1).First();
                        highscore.WriteLine(line.Replace(line, $"{operation}: {score}"));
                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.ToString());
            }
        }
        */

        static void Addition()
        {
            int num1; int num2;
            int result;
            int answer;
            int score = 0;
            Random number = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n[ Addition ]\n\nESC to Exit\nScore: {score}\n\n");

                num1 = number.Next(10, 1000);
                num2 = number.Next(10, 1000);
                result = num1 + num2;

                string question = $"{num1} + {num2} = ";
                Console.Write(question);

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Operation();
                }
                
                answer = Convert.ToInt32(Console.ReadLine());

                if (answer == result)
                {
                    score++;
                    continue;
                }
                else
                {
                    score--;
                    continue;
                }
            }
        }

        static void Subtraction()
        {
            int num1; int num2;
            int result;
            int score = 0;
            Random number = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n[ Subtraction ]\n\nESC to Exit\nScore: {score}\n\n");

                num1 = number.Next(10, 1000);
                num2 = number.Next(10, 1000);
                result = num1 - num2;

                string question = $"{num1} - {num2} = ";
                Console.Write(question);
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Operation();
                }
                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == result)
                {
                    score++;
                    continue;
                }
                else
                {
                    score--;
                    continue;
                }
            }
        }

        static void Multiplication()
        {
            int num1; int num2;
            int result;
            int score = 0;
            Random number = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n[ Multiplication ]\n\nESC to Exit\nScore: {score}\n\n");

                num1 = number.Next(2, 100);
                num2 = number.Next(2, 100);
                result = num1 * num2;

                string question = $"{num1} * {num2} = ";
                Console.Write(question);

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Operation();
                }
                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == result)
                {
                    score++;
                    continue;
                }
                else
                {
                    score--;
                    continue;
                }
            }
        }

        static void Division()
        {
            int num1; int num2;
            double result;
            int score = 0;
            Random number = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n[ Division ]\n\nESC to Exit\nScore: {score}\n\n");

                num1 = number.Next(2, 100);
                num2 = number.Next(2, 100);
                result = num1 / num2;

                string question = $"{num1} / {num2} = ";
                Console.Write(question);

                if(Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Operation();
                }
                double answer = Convert.ToDouble(Console.ReadLine());

                if (answer == result)
                {
                    score++;
                    continue;
                }
                else
                {
                    score--;
                    continue;
                }
            }
        }
    }
}
