using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultät
{
    internal class Program
    {
        static void Main(string[] args)


        {

            //Begrüßung (Name, Geschlecht)
            Console.WriteLine("Guten Tag! Wie lautet ihr Name?");
            string name = Console.ReadLine();

            Console.WriteLine("Sind Sie männlich oder weiblich?");
            string geschlecht = Console.ReadLine();

            {

                while (true)

                    if (geschlecht.Contains("männlich"))
                    {

                        Console.WriteLine("    ");
                        Console.Write("Servus Herr " + name);
                        break;
                    }
                    else if (geschlecht.Contains("weiblich"))
                    {
                        Console.WriteLine("    ");
                        Console.Write("Servus Frau " + name);
                        break;

                    }
                    else
                    {
                        Console.Write("Tut mir leid Sie müssen ihr Geschlecht eingeben");





                    }


                Console.WriteLine(" ");
                Console.WriteLine("Noch ein kleiner Tipp, zum Beenden exit eingeben");
                while (true)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Welche Zahl möchten sie fakulieren");
                    string eingabe = Console.ReadLine();


                    if (int.TryParse(eingabe, out int n) && n >= 0 && n < 10)


                    {

                        long result = 1;
                        for (int i = 1; i <= n; i++)


                        {
                            result *= i;


                            if (i < n)
                            { Console.Write($"{i}*");
                            }
                            else
                            {
                                Console.Write($"{i} = ");

                            }
                        }

                        Console.WriteLine(result);

                    }

                    else if (eingabe.Contains("exit"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Falscher Wert");
                    }
                }


            }
        }
    }