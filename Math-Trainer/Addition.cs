using System;

namespace Math_Trainer
{
    class Addition : IOperation
    {
        public string Name { get => "addition"; }

        public Challenge GetChallenge(Random random)
        {
            int num1 = random.Next(10, 1000);
            int num2 = random.Next(10, 1000);
            string question = $"{num1} + {num2} = ";
            int answer = num1 + num2;
            return new Challenge
            {
                Question = question,
                Answer = answer.ToString()
            };
        }
    }
}
