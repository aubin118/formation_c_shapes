using EBanque;
using TBanque;
using System;
using System.IO;

namespace SBanque
{
    public class Sortie
    {
        private FileStream file;
        private StreamWriter str;

        public Sortie()
        {
            string NomFichier;

            Console.WriteLine("Entrez le nom du chemin du fichier de sortie des transactions");
            NomFichier = Console.ReadLine();

            ///NomFichier = "Resultat.txt";

            file = File.OpenWrite(NomFichier);

            str = new StreamWriter(file);
        }

        public void Ecriture_status(long idtran, Status status)
        {
            str.WriteLine(idtran + ";" + status);
        }
        public void Fermer_status()
        {
            str.Close();
            file.Dispose();
        }
    }
}
