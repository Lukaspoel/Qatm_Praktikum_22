using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Fakultät von n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int ergebnis = 1;
            for (int i = n; i >= 1; i--)
            {
                ergebnis *= i;
            }
            Console.WriteLine(ergebnis);
            Console.ReadKey();
        }
    }
}
