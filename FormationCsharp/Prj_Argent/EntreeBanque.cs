using TBanque;
using CBBanque;
using CptBanque;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBanque
{
    
    public class Entree
    {
        
        public Dictionary<string, CarteB> CB_fichier()
        {
            string NomFichier = " ";
            while (!File.Exists(NomFichier))
            {
                Console.WriteLine("Entrez le nom du chemin du fichier des cartes");
                NomFichier = Console.ReadLine();

                ///NomFichier = "Cartes.csv";

            }
            FileStream file = File.Open((NomFichier), FileMode.Open, FileAccess.Read);
            Dictionary < string, CarteB> dict_carte = new Dictionary<string, CarteB >();
            using (StreamReader str = new StreamReader(file))
            {
                while (!str.EndOfStream)
                {
                    CarteB carte = new CarteB(str.ReadLine());
                    if (!string.IsNullOrWhiteSpace(carte._CBNumCarte))
                    {
                        if (!dict_carte.ContainsKey(carte._CBNumCarte))
                        {
                            dict_carte.Add(carte._CBNumCarte, carte);
                        }
                    }
                    
                }
            }
            file.Dispose();
            return dict_carte;
        }
        public Dictionary<long, CptB> Cpt_fichier()
        {
            string NomFichier = " ";
            while (!File.Exists(NomFichier))
            {
                Console.WriteLine("Entrez le nom du chemin du fichier des comptes");
                NomFichier = Console.ReadLine();

                ///NomFichier = "Comptes.csv";
            }
            FileStream file = File.Open((NomFichier), FileMode.Open, FileAccess.Read);

            Dictionary<long, CptB> dict_cpt = new Dictionary<long, CptB>();
            using (StreamReader str = new StreamReader(file))
            {
                while (!str.EndOfStream)
                {
                    CptB cpt = new CptB(str.ReadLine());
                    if (cpt._CptNumCpt != 0) 
                    {
                        if (!dict_cpt.ContainsKey(cpt._CptNumCpt))
                        {
                            dict_cpt.Add(cpt._CptNumCpt, cpt);
                        }
                    }
                }
            }
            file.Dispose();
            return dict_cpt;
        }

        private FileStream fileT;
        public StreamReader strT { get; private set; }
        public void Transaction_fichier_open()
        {
            string NomFichier = " ";
            while (!File.Exists(NomFichier))
            {
                Console.WriteLine("Entrez le nom du chemin du fichier d'entrée des transactions");
                NomFichier = Console.ReadLine();

                ///NomFichier = "Transactions.csv";
            }
            fileT = File.Open((NomFichier), FileMode.Open, FileAccess.Read);
            strT = new StreamReader(fileT);

        }
        public Transaction Transaction_lecture()
        {
            
                Transaction T = new Transaction(strT.ReadLine());
                return T;
            
        }
        public void Transaction_Fermer()
        {
            strT.Close();
            fileT.Dispose();
        }


    }
    
}
