using System;

namespace TestArea
{
    interface IOperation
    {
        string Name { get; }
        Challenge GetChallenge(Random random);
    }
}
