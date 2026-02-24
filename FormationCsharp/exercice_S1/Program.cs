using Serie_I;
using Serie_II;
using Serie_III;
using Serie_VI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_S1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            /*ElementaryOperations.BasicOperation(6, 4, '+');
            ElementaryOperations.BasicOperation(6, 4, '-');
            ElementaryOperations.BasicOperation(3, 4, '-');
            ElementaryOperations.BasicOperation(6, 4, '*');
            ElementaryOperations.BasicOperation(6, 4, '/');
            ElementaryOperations.BasicOperation(6, 0, '/');
            ElementaryOperations.BasicOperation(6, 4, 'e');

            ElementaryOperations.IntegerDivision(6, 4);
            ElementaryOperations.IntegerDivision(8, 4);
            ElementaryOperations.IntegerDivision(6, 0);

            ElementaryOperations.Pow(6, 2);
            ElementaryOperations.Pow(6, -2);

            string message = SpeakingClock.GoodDay(1);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(8);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(12);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(14);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(18);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(23); 
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(-1);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(102);
            Console.WriteLine(message);
            
*/
            Pyramid.PyramidConstruction(10, false);
            int x = 12;
            long a;
            Stopwatch sw = Stopwatch.StartNew();

            sw.Restart();
            Factorial.Factorial_(x);
            sw.Stop();
            Console.WriteLine($"temps factorial  {sw.ElapsedTicks}");
            sw.Restart();

            sw.Start();
            Factorial.FactorialRecursive(x, x);
            sw.Stop();
            Console.WriteLine($"temps factorial recursive  {sw.ElapsedTicks}");
            sw.Restart();

            sw.Start();
            a = Factorial.FactorialRecursivevrai(x);
            Console.Write($" {x}! = {a} ");
            sw.Stop();
            Console.WriteLine($"temps factorial recursive 'vrai' {sw.ElapsedTicks}");

            
            */
            /*int x = 12 - 2 * 3;
            Console.WriteLine("La valeur de x est : " + x);
            string entree = Console.ReadLine();
            Console.WriteLine("la valeur de l'entrée est : " + entree);
            int y = 12;
            int z = x + y;

            string phrase = Console.ReadLine();

            int entier;
            bool res = int.TryParse(phrase, out entier);

            int[] nom = {5, 2, 3, 4, 5};
            //Console.WriteLine("ca tableau " + nom);
            foreach (int l in nom)
            {
                Console.Write("ca tableau " + l);
            }
            foreach (int e in nom)
            {
                Console.WriteLine("ca tableau " + e);
            }

            if (res == true) {
                Console.WriteLine("ca passe");
            }
            else { 
                Console.WriteLine("ca passe pas");
            }
            /*
            Console.WriteLine($"la valeur de z est : {z:000.00}");
            if ( y  > 22) { 
                Console.WriteLine($"la valeur de y est inf à 22");
            }
            else if (y == 22)
            {
                Console.WriteLine($"la valeur de y est ega à 22");
            }
            else
            {
                Console.WriteLine($"la valeur de y est sup à 22");
            }
            int d = additionentier(ref z, 5);
            */
            Console.ReadKey();
           
        }
        public static int additionentier(ref int a, int b)
        {
            a++;
            return a + b; 
        }
        
    }
}
