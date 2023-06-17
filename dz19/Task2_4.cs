using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz19
{
    internal class Task2_4
    {
        public static void Run()
        {
            List<Journal> journals = new List<Journal>();
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1-show current list, 2-add new journal, 3-save current list, 4-read list):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Current journals:");
                        Console.WriteLine(string.Join("\n", journals));
                        break;
                    case 2:
                        Journal journal = new Journal();
                        journal.Init();
                        journals.Add(journal);
                        break;
                    case 3:
                        Journal.Save(journals);
                        break;
                    case 4:
                        journals = Journal.Read();
                        break;
                }
            } while (choice != 0);
        }
    }
}
