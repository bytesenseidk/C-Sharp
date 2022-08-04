using System;

namespace BodyMassIndex
{
    class SuperClass
    {
        private double weight;
        private double height;

        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value < 1 ? Math.Abs(value) : value;
            }
        }
        public double Height
        {
            get { return height; }
            set 
            { 
                height = value < 1 ? Math.Abs(value) : value; 
            }
        }

        public virtual string Values()
        {
            return $"Weight: {Weight}\nHeight: {Height}";
        }
    }
    internal class BaseClass : SuperClass
    {
        public BaseClass(double weight, double height)
        {
            Weight = weight;
            Height = height;
        }
        public double BMI()
        {
            return Math.Round(Weight / Height / Height * 10_000, 2);
        }
        public override string Values()
        {
            return base.Values() + $"\nBMI: \t{BMI()}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass Bmi = new(100, 175);
            Console.WriteLine(Bmi.Values());   
        }
    }
}
