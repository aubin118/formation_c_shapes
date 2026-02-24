using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
            
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < (1 + n * 2); i++)
                {
                    if ((i < n - j) | (i > (2*n)-(n-j)))
                    {
                        Console.Write(" ");
                    }

                    else
                    {
                        if (isSmooth)
                        {
                            Console.Write("+");
                        }
                        else 
                        {
                            if ((j+1) % 2 == 0)
                            {
                                Console.Write("-");
                            }
                            else
                            {
                                Console.Write("+");
                            }
                                 
                        }

                     }
                }
                Console.WriteLine();

            }
        }
    }
}
