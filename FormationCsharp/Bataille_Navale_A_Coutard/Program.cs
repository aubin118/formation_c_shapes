using Bataille_Navale;


/////////// Réponse aux questions
/*

2) a) Le bateau est coulé si aucune de ses positions sont restées à l'état "caché".

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
