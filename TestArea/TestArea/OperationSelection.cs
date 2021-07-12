using System;
using System.Linq;
using System.Collections.Generic;

namespace TestArea
{
    class OperationSelection
    {
        readonly Dictionary<string, IOperation> operationsDict;

        public OperationSelection()
        {
            IEnumerable<IOperation> operations = new IOperation[]
            {
                new Addition(),
                new Subtraction(),
                new Multiplication(),
                new Division()
            };
            
            operationsDict = operations.ToDictionary(operation => operation.Name, operation => operation);
        }

        public IOperation GetOperation()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("[ Operation Selection ]\n");

                Console.WriteLine("Type one of the following:\n");
                foreach (string operationName in operationsDict.Keys)
                {
                    Console.WriteLine($"[ {operationName} ]\n");
                }

                string response = Console.ReadLine();
                if(operationsDict.TryGetValue(response, out IOperation operation))
                {
                    return operation;
                }
                else { Console.WriteLine("Unknown Operation."); }
            }
        }
    }
}