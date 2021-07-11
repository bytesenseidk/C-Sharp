using System;

namespace TestArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] questionData = Addition();
            AskQuestion(questionData[0], questionData[1], questionData[2]);
        }

        static void AskQuestion(int num1, int num2, int result)
        {
            string question = $"{num1} + {num2} = ";

            Console.Clear();
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

        static int[] Addition()
        {
            int num1; int num2; 
            int result;
            Random number = new Random();

            num1 = number.Next(10, 1000);
            num2 = number.Next(10, 1000);
            
            result = num1 + num2;

            int[] data = { num1, num2, result };
            
            return data;
        }
    }
}
