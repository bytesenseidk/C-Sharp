using System;

namespace BodyMassIndex
{
    // Super Class
    class BaseClass
    {
        private double weight;
        private double height;

        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value < 1 ? 100 : value;
            }
        }
        public double Height
        {
            get { return height; }
            set 
            { 
                height = value < 1 ? 100 : value; 
            }
        }

        public virtual string Values()
        {
            return $"Weight: {Weight}\nHeight: {Height}";
        }
    }
    // Base Class
    class DerivedClass : BaseClass
    {
        public DerivedClass(double weight, double height)
        {
            Weight = weight;
            Height = height;
        }
        public double BMI()
        {
            return Math.Round(Weight / Height / Height * 10_000, 2);
        }
        // Polymorphism
        public override string Values()
        {
            return base.Values() + $"\nBMI: {BMI()}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass Bmi = new(100, 175);
            Console.WriteLine(Bmi.Values());   
        }
    }
}
