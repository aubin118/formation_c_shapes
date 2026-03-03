using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bataille_Navale
{
    internal class Plateau
    {
        public Position[,] PlateauJeu { get; set; }

        public List<Bateau> Bateaux { get; set; }

        public Plateau(int taille)
        {
            PlateauJeu = new Position[10, 10];
            Bateaux = new List<Bateau>()
            {
               new Bateau("A", 5, new List<Position>()),
               new Bateau("B", 4, new List<Position>()),
               new Bateau("C", 3, new List<Position>()),
               new Bateau("D", 3, new List<Position>()),
               new Bateau("E", 2, new List<Position>())
            };
        }

        public void CreationPlateau()
        {
            int valx = 0;
            int valy = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
            {
                    PlateauJeu[i, j] = new Position(i, j);
                }

            }
            
            Random aleatoire = new Random();
            valx = 0;
            valy = 0;
            bool valide;
            int taille;
            bool estVertical = false;
            foreach (Bateau bateau in Bateaux)
            {
                valide = false;
                taille = bateau.Taille;
                while (!valide)
                {
                    valx = aleatoire.Next(10);
                    valy = aleatoire.Next(10);
                    if (aleatoire.Next() % 2 == 0)
                    {
                        estVertical = false; 
                    }
                    else 
                    {
                        estVertical = true;
                    }
                    valide = PlacerBateau(valx, valy,taille, estVertical );
                }
                if (estVertical)
                {
                    for (int i = 0; i < taille; i++)
                    {
                        bateau.Positions.Add(PlateauJeu[valx, valy + i]);
                        //bateau.Positions.Add(new Position(valx, valy + i));
                    }
                }
                else
                {
                    for (int i = 0; i < taille; i++)
                    {
                        bateau.Positions.Add(PlateauJeu[valx + i, valy]);
                        //bateau.Positions.Add(new Position(valx + i, valy ));
                    }
                }
            }
        }
        
        public void LancementPartie()
        {
            int cpt = 0;

            CreationPlateau();

            while (!FindePartie())
            {
                Console.Clear();
                AfficherPlateau();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Quelle case visez-vous : (format: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("ligne");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(",");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("colonne");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".");
                Console.WriteLine();

                string val = Console.ReadLine();
                string[] position = val.Split(',', '.');
                int[] PositionNum = new int[2];
                if (position.Length >= 2 &&
                    int.TryParse(position[0], out PositionNum[0])&&
                    int.TryParse(position[1], out PositionNum[1]))
                {
                    if (PositionNum[0] >= 1 && PositionNum[0] <= 10 &&
                        PositionNum[1] >= 1 && PositionNum[1] <= 10)
                    {
                        PositionNum[0] -= 1;
                        PositionNum[1] -= 1;
                        cpt++;
                        Viser(PositionNum[0], PositionNum[1]);
                        
                    }
                    else
                    {
                        Console.WriteLine("Valeur hors de la plage autorisée, appuyer pour continuer");
                        Console.ReadKey();
                    }
                }
                else 
                {
                    Console.WriteLine("Format de coordonnées invalides, appuyer pour continuer");
                    Console.ReadKey();
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            AfficherPlateau();
            Console.Write($"GG {cpt} coups effectués !");
        }

        /// <summary>
        /// Peut-on placer le navire sur la grille sans qu'il dépasse les bords et qu'il ne touche les autres bateaux ? 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="taille"></param>
        /// <param name="estVertical"></param>
        /// <returns></returns>
        private bool PlacerBateau(int x, int y, int taille, bool estVertical)
        {
            // Bien de prendre en compte les cas limites avant les foreach
            if (x <= 10 && y <= 10 && x >= 0 && y >= 0)
            {
                if (estVertical)
                {
                    if (y + taille <= 10)
                    {
                        foreach (Bateau bateau in Bateaux)
                        {
                            foreach (Position position in bateau.Positions)
                            {
                                if ((x - 1 <= position.X & x + 1 >= position.X) && (y - 1 <= position.Y & y + taille + 1 >= position.Y))
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                }
                else
                {
                    if (x + taille <= 10)
                    {
                        // Approche propre et fonctionnelle
                        foreach (Bateau bateau in Bateaux)
                        {
                            foreach (Position position in bateau.Positions)
                            {
                                if ((x - 1 <= position.X & x + taille + 1 >= position.X) && (y - 1 <= position.Y & y + 1 >= position.Y))
                                {
                                    return false;
                                }

                            }
                        }
                        return true;
                    }
                }
            }
            return false;    
        }

        /// <summary>
        /// Choix de la case (x , y) 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Viser(int x, int y)
        {
            bool toucher = false;
            foreach (Bateau bateau in Bateaux)
            {
                foreach (Position position in bateau.Positions)
                {
                    if (x == position.X && y == position.Y )
                    {
                        position.Touché();
                        toucher = true;
                        break;
                    }
                }
            }
            if (toucher) 
            {
                // Si les positions de PlateauJeu[x,y] étaient référencées dans les Bateaux, tu n'aurais pas besoin de faire ça
                PlateauJeu[x, y].Touché();
            }
            else 
            {
                PlateauJeu[x, y].Plouf();
            }

        }

        /// <summary>
        /// Affichage de l'état de la grille et de la situation de la partie
        /// </summary>
        public void AfficherPlateau()
        {
            List<Position> list = new List<Position>();
            foreach (Bateau b in Bateaux)
            {
                list.AddRange(b.Positions);
                Console.WriteLine($"{b.Nom}: {b.Taille} de long, coulé: {b.EstCoulé()}");
            }

            foreach (Position p in list)
            {
                PlateauJeu.SetValue(p, p.X, p.Y);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
            int cpt = 0, tmp = 0;
            foreach (Position p in PlateauJeu)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (p.X != tmp || cpt == 0)
                {
                    if (cpt > 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write(string.Format("{0,-3}", ++cpt));
                }

                ConsoleColor foreground;
                switch (p.Statut)
                {
                    case Position.Etat.Plouf:
                        foreground = ConsoleColor.Blue;
                        break;
                    case Position.Etat.Touché:
                        foreground = ConsoleColor.Red;
                        break;
                    case Position.Etat.Coulé:
                        foreground = ConsoleColor.Green;
                        break;
                    default:
                        foreground = ConsoleColor.White;
                        break;
                }
                Console.ForegroundColor = foreground;
                Console.Write((char)p.Statut + " ");

                tmp = p.X;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        /// <summary>
        /// La partie est-elle finie ? 
        /// </summary>
        /// <returns></returns>
        internal bool FindePartie() 
		{
            foreach (Bateau bateau in Bateaux)
            {
                // Il existe la méthode bateau.EstCoulé() si jamais
                if (bateau.Positions[0].Statut != Position.Etat.Coulé) 
                {
                    return false;
                }
            }
            return true;
		}
    }
}