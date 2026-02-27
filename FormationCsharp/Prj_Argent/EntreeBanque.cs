using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBanque
{
    public class ECartes
    {
        private Dictionary<string, int> cartes;
        public ECartes()
        {
            if (!File.Exists("Cestunfichierdetest.txt"))
            {

                string NomFichier = " ";
                while (!File.Exists(NomFichier))
                {
                    Console.WriteLine("Entrez le nom du chemin du fichier des cartes");
                    NomFichier = Console.ReadLine();
                    
                }

            }
            FileStream file = File.Open(("Cestunfichierdetest.txt"), FileMode.Open, FileAccess.ReadWrite);

            using (StreamReader str = new StreamReader(file))
            {
                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    string num_carte = line.Substring(0, 16);
                    int plafond;
                    if (int.TryParse(line.Remove(0, 17), out plafond))
                    {
                        cartes.Add(num_carte, plafond);
                    }
                }
            }
            file.Dispose();
        }
    }
}
