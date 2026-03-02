using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBBanque;

namespace EBanque
{
    
    public class ECartes
    {
        
        public CarteB CB_fichier()
        {
            string NomFichier = " ";
            while (!File.Exists(NomFichier))
            {
                Console.WriteLine("Entrez le nom du chemin du fichier des cartes");
                NomFichier = Console.ReadLine();

            }

           
            FileStream file = File.Open((NomFichier), FileMode.Open, FileAccess.ReadWrite);
            CarteB carte = new CarteB();
            using (StreamReader str = new StreamReader(file))
            {
                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    carte.Add_carte_line(line);
                }
            }
            file.Dispose();
            return carte;
        }

    }
    
}
