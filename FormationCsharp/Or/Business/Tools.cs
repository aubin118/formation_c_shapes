using Or.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Or.Business
{
    /// <summary>
    /// Enumération décrivant le type de transaction
    /// Facilite la prise en charge par GestionBancaire
    /// </summary>
    public enum Operation
    {
        DepotSimple = 0,
        RetraitSimple = 1,
        InterCompte = 2
    }

    public enum Erreur
    {
        MontantInvalide = 1,
        MontantNegative,
        SoldeInsuffisant,
        Compte_Livret,
        Compte_inexistant,
        Plafond_insuffisant
    }

    public static class Tools
    {
        public static Erreur Code_Erreur;
        public static DateTime ConversionDate(string horodatage)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            return DateTime.ParseExact(horodatage, "dd/MM/yyyy HH:mm:ss", culture);
        }

        /// <summary>
        /// Est ce que l'identifiant désigne l'extérieur ?
        /// </summary>
        /// <param name="identifiant"></param>
        /// <returns></returns>
        private static bool EstExterieur(int identifiant)
        {
            return identifiant == 0;
        }

        /// <summary>
        /// Est ce que la transaction est Extérieur -> Extérieur ?
        /// Si oui, elle est invalide
        /// </summary>
        /// <param name="expediteur"></param>
        /// <param name="destinataire"></param>
        /// <returns></returns>
        public static bool EstTransactionExterieure(int expediteur, int destinataire)
        {
            return expediteur + destinataire == 0;
        }


        public static Operation TypeTransaction(int expediteur, int destinataire)
        {
            // 0 -> Compte
            if (EstExterieur(expediteur))
            {
                return Operation.DepotSimple;
            }
            // Compte -> Compte
            else if (EstExterieur(destinataire))
            {
                return Operation.RetraitSimple;
            }
            // Compte -> Compte
            else
            {
                return Operation.InterCompte;
            }
        }

        public static string RetourErreur() 
        {
            
            switch (Code_Erreur)
            {
                case Erreur.MontantInvalide:
                    return "Montant invalide";
                case Erreur.MontantNegative:
                    return "Montant doit être positif";
                case Erreur.SoldeInsuffisant:
                    return "Solde insuffisant";
                case Erreur.Compte_Livret:
                    return "Virement externe que sur compte courant";
                case Erreur.Compte_inexistant:
                    return "Compte inexistant";
                case Erreur.Plafond_insuffisant:
                    return "Plafond insuffisant";
                default:
                    return "Erreur indéfinie";
            }
            

        }
    }
}
