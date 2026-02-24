using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2_III
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                if (valeur == tableau [i]) {  return i; }
                
            }
            return -1;
                
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            int i = tableau.Length /2 ;        
            int e = 1;
            while (valeur != tableau[i])
            {
                e++;
                //Console.WriteLine(" passe" + tableau[i]);
                if (valeur < tableau[i]) 
                { 
                    i = i - (tableau.Length / (2*e));
                } 
                else
                {
                    i = i + (tableau.Length / (2 * e));
                }
                if ((tableau.Length / (2 * e) == 0)) { return -1; }
                


            }

            return i;
        }
    }
}
