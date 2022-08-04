using System;
using System.Linq;
using System.Collections.Generic;

namespace Math_Trainer
{
    class OperationSelection
    {
        // This method lets the player choose which operation they wish to train
        readonly Dictionary<string, IOperation> operationsDict;

        public OperationSelection()
        {
            // Gets operations from Operation.cs
            IEnumerable<IOperation> operations = new IOperation[]
            {
                // Array of available methods
                new Addition(),
                new Subtraction(),
                new Multiplication(),
                new Division()
            };
            // Converts array to dictionary
            operationsDict = operations.ToDictionary(operation => operation.Name, operation => operation);
        }

        public IOperation GetOperation()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ Operation Selection ]\n");

                Console.WriteLine("Type one of the following:\n");
                // Loops through and prints each operation key/name
                foreach (string operationName in operationsDict.Keys)
                {
                    Console.WriteLine($"[ {operationName} ]\n");
                }

                string response = Console.ReadLine();
                // Checks if response corresponds to a dictionary key
                if (operationsDict.TryGetValue(response, out IOperation operation))
                {
                    // Executes the choosen operation
                    return operation;
                }
                else { Console.WriteLine("Unknown Operation."); }
            }
        }
    }
}
