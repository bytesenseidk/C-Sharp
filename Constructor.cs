using System;

namespace Mixed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicArithmetic multi = new BasicArithmetic(7, 9);
            System.Console.WriteLine(multi.addition());
        }
    }

    public class BasicArithmetic
    {
        private double a;
        private double b;

        public BasicArithmetic(double num_0, double num_1)
        {
            a = num_0;
            b = num_1;
        }

        public double addition()
        {
            return a + b;
        }
    }
}