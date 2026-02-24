using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Serie2_II
{
    public static class Morpion
    {
        public static void DisplayMorpion(char[,] tab)
        {
            Console.WriteLine(" Affichage grille de Morpion :");
            for (int i = 0; i < tab.GetLength(0); i++ )
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i,j] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return;
        }

        public static int CheckMorpion(char[,] tab)
        {
            int result = -1;
            //vérifie les lignes
            for (int i = 0; i < tab.GetLength(0); i++) {
                if ((tab[i, 0] == 'X') && (tab[i, 0] == tab[i, 1]) && (tab[i, 2] == tab[i, 1]))
                {
                    return result = 1;
                }
                if ((tab[i, 0] == 'O') && (tab[i, 0] == tab[i, 1]) && (tab[i, 2] == tab[i, 1]))
                {
                    return result = 2;
                }
                if ((tab[0, i] == 'X') && (tab[0, i] == tab[1, i]) && (tab[2, i] == tab[1, i]))
                {
                    return result = 1;
                }
                if ((tab[0, i] == 'O') && (tab[0, i] == tab[1, i]) && (tab[2, i] == tab[1, i]))
                {
                    return result = 2;
                }
            }
            // verifie les diagonales
            if ((tab[0, 0] == 'X') && (tab[1, 1] == tab[0, 0]) && (tab[2, 2] == tab[1, 1]))
            {
                return result = 1;
            }
            if ((tab[0, 0] == 'O') && (tab[1, 1] == tab[0, 0]) && (tab[2, 2] == tab[1, 1]))
            {
                return result = 2;
            }
            if ((tab[0, 2] == 'X') && (tab[1, 1] == tab[0, 2]) && (tab[2, 0] == tab[1, 1]))
            {
                return result = 1;
            }
            if ((tab[0, 2] == 'O') && (tab[1, 1] == tab[0, 2]) && (tab[2, 0] == tab[1, 1]))
            {
                return result = 2;
            }
             
            foreach (char chat in tab)
            {
                if (chat == '_') { return result = -1; }
            }

            return result = 0;

        }
    }
}
