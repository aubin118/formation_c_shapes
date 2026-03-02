using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bataille_Navale;


/////////// Réponse aux questions
/*

2) a) Le bateau est coulé si aucune de ses position sont restés cachés.

7) a) La partie se termine lorsque tous les bateaux sont coulés.


*/

namespace Bataille_Navale_A_Coutard

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plateau jeu = new Plateau(10);
            jeu.LancementPartie();
        }
    }
}
