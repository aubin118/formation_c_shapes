using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2_I
{
    public static class TasksTables
    {
        public static int SumTab(int[] tab)
        {
            if (tab.Length > 0)
            {
                int somme = 0;
                foreach (int i in tab)
                {
                    somme += i;
                }
                return somme;
            }
            else { return -1; }
        }

        public static int[] OpeTab(int[] tab, char ope, int b)
        {
            int[] tab_ope = new int[tab.Length];
            int[] tab_vide = {};

            if (tab.Length > 0)
            {
                int e = 0;
                switch (ope)
                {
                    case '+':
                        foreach (int i in tab)
                        {
                            tab_ope[e] = i + b;
                            e++; 
                        }
                        break;
                    case '-':
                        foreach (int i in tab)
                        {
                            tab_ope[e] = i - b;
                            e++;
                        }
                        break;
                    case '*':
                        foreach (int i in tab)
                        {
                            tab_ope[e] = i * b;
                            e++;
                        }
                        break;
                    default:
                        return tab_vide;

                }
                return tab_ope;
            }
            else { return tab_vide; }
        }

        public static int[] ConcatTab(int[] tab1, int[] tab2)
        {
            int[] tab_concat = new int[tab1.Length + tab2.Length];
            int e = 0;
            foreach (int i in tab1)
            {
                tab_concat[e] = i;
                e++;
            }
            foreach (int i in tab2)
            {
                tab_concat[e] = i;
                e++;
            }

            return tab_concat;
        }
    }
}
