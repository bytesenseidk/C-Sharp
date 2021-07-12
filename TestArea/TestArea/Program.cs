namespace TestArea
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationSelection selection = new OperationSelection();

            OperationPlayer player = new OperationPlayer();

            while(true)
            {
                IOperation operation = selection.GetOperation();
                player.PlayOperation(operation);
            }
        }
    }
}
