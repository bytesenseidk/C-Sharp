using System;

namespace TestArea
{
    class Division: IOperation
    {
        public string Name { get => "division"; }
        
        public Challenge GetChallenge(Random random)
        {
            decimal num1 = random.Next(10, 1000);
            decimal num2 = random.Next(10, 1000);
            string question = $"{num1} ÷ {num2} (two decimal places) = ";
            decimal answer = Math.Round(num1 / num2, 2);
            return new Challenge
            {
                Question = question,
                Answer = answer.ToString()
            };
        }
    }
}