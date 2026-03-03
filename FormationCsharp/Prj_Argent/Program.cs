using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Argent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "555;55555555555555;livret;0000";
            string b = "555;55555555555555;livret;";
            string[] atab = a.Split(';');
            string[] btab = b.Split(';');
            Console.WriteLine(atab.Length);
            foreach (string s in atab)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("bbbbbbbbbbbbbbbbb");
            Console.WriteLine(btab.Length);
            foreach (string s in btab)
            {
                Console.WriteLine(s);
            }

            if (string.IsNullOrWhiteSpace(a)) { Console.WriteLine("null"); }
                
        }
    }
}
