using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_VI
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            if (n > 0)
            {

                int c = 1;
                for (int i = 1; i < (n+1); i++)
                {
                    c *= i;
                }
                Console.Write($" {n}! = {c} ");
            }
            else
            {
                Console.Write($" Calcul impossible avec {n} ");
            }
                return -1;
        }

        public static int FactorialRecursive(int n,int i, long c = 1)
        {
            if (n > 0)
            {
                if (i == 0)
                {
                    Console.Write($" {n}! = {c} ");
                }
                else
                {
                    c *= i;
                    i--;
                    Factorial.FactorialRecursive(n,i, c);
                }
            }
            else
                {
                Console.Write($" Calcul impossible avec {n} ");
                }

            return -1;
        }
        public static long FactorialRecursivevrai(long n)
        {
            if (n > 0)
            {
                if (n == 1) {
                    return 1;
                } 
            }
            else
            {
                Console.Write($" Calcul impossible avec {n} ");
                return -1;
            }

            return n*FactorialRecursivevrai(n-1);
        }
    }
}
