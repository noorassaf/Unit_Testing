using System;
namespace Unit_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightCalc WrighCalc = new WeightCalc {
                height = 180,
                sexe ='m'
            };
            double weight = WrighCalc.getweight();
            Console.WriteLine($"weight={ weight}"); 
            if(weight == 72.5 ) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(  "test succeeded");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("test fail");
            }

            WrighCalc.sexe = 'w';
            weight = WrighCalc.getweight();

            if (weight == 72.5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("test succeeded");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("test fail");
            }
            Console.ReadKey();
        }
    }
}