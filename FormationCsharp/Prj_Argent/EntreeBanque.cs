using TBanque;
using CBBanque;
using CptBanque;
using System;
using System.Collections.Generic;
using System.IO;

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
            // Pk pas using pour FileStream ? 
            FileStream file = File.Open((NomFichier), FileMode.Open, FileAccess.Read);
            Dictionary<string, CarteB> dict_carte = new Dictionary<string, CarteB>();
            using (StreamReader str = new StreamReader(file)) // bonne pratique
            {
                while (!str.EndOfStream)
                {
                    // OK, mais c'est bizarre de créer une instance de CarteB si les données ne sont pas valides. 
                    CarteB carte = new CarteB(str.ReadLine());
                    if (!string.IsNullOrWhiteSpace(carte.CBNumCarte))
                    {
                        // OK
                        if (!dict_carte.ContainsKey(carte.CBNumCarte))
                        {
                            dict_carte.Add(carte.CBNumCarte, carte);
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
                // Pour respecter les consignes il faudrait passer le nom du fichier en entrée (ce serait un argument de l'exécutable)
                Console.WriteLine("Entrez le nom du chemin du fichier des comptes");
                NomFichier = Console.ReadLine();
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

        // Pas faux, mais attention, dans tous les cas Close() et Dispose() doivent toujours être appelées
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
