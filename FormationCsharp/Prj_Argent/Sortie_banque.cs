using EBanque;
using TBanque;
using CBBanque;
using CptBanque;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBanque
{
    public class Sortie
    {
        private FileStream file;
        private StreamWriter str;

        public Sortie() 
        {
            string NomFichier = " ";
            while (!File.Exists(NomFichier))
            {
                Console.WriteLine("Entrez le nom du chemin du fichier des comptes");
                NomFichier = Console.ReadLine();

            }
            file = File.Open((NomFichier), FileMode.Open, FileAccess.Read);

            
            str = new StreamWriter(file);
            
            
            
        }
        public void Ecriture_status (long idtran, Status status) 
        {
            str.WriteLine(idtran + "  "+ status);
        }
        public void Fermer_status()
        {
            str.Close();
            file.Dispose();
        }
    }
}
