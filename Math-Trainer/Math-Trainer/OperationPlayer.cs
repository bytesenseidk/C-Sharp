using System;
using System.Linq;
using System.Collections.Generic;

namespace Math_Trainer
{
    class OperationPlayer
    {
        // This method loops until the user decides to quit
        readonly Random random = new Random();
        int score = 0;

        public void PlayOperation(IOperation operation)
        {
            // Fetches operation from Operation.cs
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"[ {operation.Name} ]");
                Console.WriteLine($"Score: {score}");

                SendChallenge(operation.GetChallenge(random));
                if (!KeepPlaying()) { return; }
            }
        }

        void SendChallenge(Challenge challenge)
        {
            // Fetches question from Operation.cs
            Console.Write(challenge.Question);
            string response = Console.ReadLine();
            bool correct = challenge.Answer == response;
            if (correct) { score++; }
            string result = correct ? "Correct!" : "Incorrect.";
            Console.WriteLine(result);
        }

        bool KeepPlaying()
        {
            Console.WriteLine("ESC to exit; ENTER to continue.");
            ConsoleKey response = Console.ReadKey().Key;

            //ESC key prevents the next character from being printed
            Console.Write('x');

            return !(response == ConsoleKey.Escape);
        }
    }
}
