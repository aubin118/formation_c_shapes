using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
            switch (operation)
            {
                case '+':
                    Console.WriteLine($"{a} + {b} = {a += b} ");
                    break;
                case '-':
                    Console.WriteLine($"{a} - {b} = {a -= b} ");
                    break;
                case '*':
                    Console.WriteLine($"{a} * {b} = {a *= b} ");
                    break;
                case '/':
                    if (b != 0)
                    {
                        Console.WriteLine($"{a} / {b} = {a /= b} ");
                    }
                    else
                    {
                        Console.WriteLine($"{a} / {b} = Opération invalide. ");
                    }
                    break;
                default:
                    Console.WriteLine($"{a} {operation} {b} = Opération invalide. ");
                    break;

            }
        }


        public static void IntegerDivision(int a, int b)
        {
            if (b != 0)
                if (a % b != 0)
                {
                    int c = a % b;
                    Console.WriteLine($"{a} = {a /= b} * {b} + {c} ");
                }
                else
                {
                    Console.WriteLine($"{a} = {a /= b} * {b} ");
                }
            else
            {
                Console.WriteLine($"{a} : {b} = Opération invalide. ");
            }
        }

        public static void Pow(int a, int b)
        {
            
            if (b >= 0)
            {
                int c = 1;
                for (int y = 0; y < b; y++)  { c *= a; }
                Console.WriteLine($"{a} ^ {b} = {c}");
            }
            else
            {
                Console.WriteLine($"{a} ^ {b} = Opération invalide. ");
            }
        }
    }
}
