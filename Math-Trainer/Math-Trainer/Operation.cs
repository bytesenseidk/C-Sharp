using System;

namespace Math_Trainer
{
    interface IOperation
    {
        string Name { get; }
        Challenge GetChallenge(Random random);
    }
}
