using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz19
{
    internal class Task1
    {
        public static void Run()
        {
            List<Fraction> fractions = new List<Fraction>();
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1-show current list, 2-add fraction, 3-save current list, 4-read list):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Current fractions:");
                        Console.WriteLine(string.Join("\n", fractions));
                        break;
                    case 2:
                        Console.WriteLine("Enter fraction(use /)");
                        string[] input = Console.ReadLine().Split('/',' ');
                        while (input.Length < 2)
                        {
                            input = input.Append("1").ToArray();
                        }
                        int.TryParse(input[0], out int num);
                        int.TryParse(input[1], out int denom);
                        fractions.Add(new Fraction(num, denom));
                        break;

                    case 3:
                        Fraction.Save(fractions);
                        break;
                    case 4:
                        fractions = Fraction.Read();
                        break;
                }
            } while (choice != 0);
        }
    }
}
