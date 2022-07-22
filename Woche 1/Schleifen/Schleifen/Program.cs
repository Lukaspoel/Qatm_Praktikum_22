using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Schleifen
{
    internal class Program
    {
        static void Main(string[] args)

        //While Schleife 
        {
            int zahl = 1;

            while (zahl <= 5)
            {
                Console.WriteLine(zahl);
                zahl += 1;
            }
            Console.ReadKey();

            //Do-While-Schleife
            zahl = 1;
            do
            {
                Console.WriteLine(zahl);
                zahl += 1;
            }
            while (zahl <= 5);
            Console.ReadKey();


            //For-Schleife

            for
                //initialisierte Zähler Variabel   //Bedingung   //Erhöte Zähler Variable
                (int i = 0; i < 7; i++)
            {

                Console.WriteLine(i);
            }
            Console.ReadKey();

            //Foreach-Schleife

            int[] zahlenListe = new int[5];

            zahlenListe[0] = 10;
            zahlenListe[1] = 20;
            zahlenListe[2] = 30;
            zahlenListe[3] = 40;
            zahlenListe[4] = 50;


            foreach (int number in zahlenListe)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }

    }

}

