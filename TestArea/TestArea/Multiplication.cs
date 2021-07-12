using System;

namespace TestArea
{
    class Multiplication: IOperation
    {
        public string Name { get => "multiplication"; }
        
        public Challenge GetChallenge(Random random)
        {
            int num1 = random.Next(10, 1000);
            int num2 = random.Next(10, 1000);
            string question = $"{num1} × {num2} = ";
            int answer = num1 * num2;
            return new Challenge
            {
                Question = question,
                Answer = answer.ToString()
            };
        }
    }
}