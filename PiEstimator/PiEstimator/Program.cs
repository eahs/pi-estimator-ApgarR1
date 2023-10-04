using System;
using System.Runtime.InteropServices.ComTypes;

namespace PiEstimator
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            
            Console.WriteLine("Pi Estimator");
            Console.WriteLine("================================================");

            n = GetNumber("Enter number of iterations (n): ");

            double pi = EstimatePi(n);
            double diff = Math.Abs(pi - Math.PI);

            Console.WriteLine();
            Console.WriteLine($"Pi (estimate): {pi}, Pi (system): {Math.PI}, Difference: {diff}");
        }

        static double EstimatePi(long n)
        {
            Random rand = new Random(System.Environment.TickCount);
            double temp = 20; // initialized this to 20 so that the first random number is always closer to pi

            for (int i = 0; i < n; i++) // loops through n times and finds the closest number to pi
            {
                double pi = rand.NextDouble() * 10;
                Console.WriteLine(pi);
                if (Math.Abs(temp - Math.PI) > Math.Abs(pi - Math.PI)) // checks whether difference of random number is greater than previous number
                {
                    temp = pi;
                }
            }
            return temp;
        }

        static long GetNumber(string prompt)
        {
            long output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Int64.TryParse(input, out output))
                {
                    return output;
                }
            }
        }
    }
}