using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH_Test_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbersToSum = new decimal[] { 5, 5, 1, 1, 2, 3, 4 };
            decimal summe = SummeAlternativ(numbersToSum);
            decimal[] numbersToSubstract = new decimal[] { 4, 4, 1, 1, 2, 3, 4 };
          
            // für verwendung l von numbers entfernen
            decimal[] numbersToSubstract2 = new decimal[] { 1, 2, 3 };
            decimal[] nlumbers = new decimal[] { 5, 5, 5 };
            decimal summe2 = Substract(nlumbers, numbersToSubstract2);

            decimal[] numbersToMultiply = new decimal[] { 1, 2, 3, 5  };
            decimal[] numbers = new decimal[] { 1, 3, 5, };
            decimal summe3 = Multiply(numbersToMultiply, numbers);
        }
  
        public static decimal Summe(decimal[] numbers)
        {
            decimal result = 0;
            foreach (decimal number in numbers)
            {
                result += number;
            }

            return result;
        }

        public static decimal SummeAlternativ(decimal[] numbers)
        {
            decimal result = 0;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            return result; 
        }                                                                                                                                                                                                                                                                                                                                                                                                   
        public static decimal Substract(decimal[] numbers, decimal[] numbersToSubstract)
        {
            decimal result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i] - numbersToSubstract[i];
            }

            return result;

        }
        
        public static decimal Multiply(decimal[] numbers, decimal[] numbersToMultiply)   
        {
            decimal result = 0;
            if (numbersToMultiply.Length == numbers.Length)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    result += numbers[i] * numbersToMultiply[i];
                }
            }
            else 
            {
                result = -1;
                
               
            }return result;

        } 
    }  
}