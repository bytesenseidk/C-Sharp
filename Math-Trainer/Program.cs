namespace Math_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lets the player choose which operation they wish to train
            OperationSelection selection = new OperationSelection();
            // Loops until the user decides to quit
            OperationPlayer player = new OperationPlayer();

            while (true)
            {
                IOperation operation = selection.GetOperation();

                player.PlayOperation(operation);
            }
        }
    }
}
