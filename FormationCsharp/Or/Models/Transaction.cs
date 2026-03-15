using Or.Business;
using System;
using System.Xml.Serialization;

namespace Or.Models
{
    public class Transaction
    {
        [XmlElement("Identifiant")]
        public int IdTransaction { get; set; }
        [XmlIgnore]
        public DateTime Horodatage { get; set; }
        
        public string Date 
        { 
            get
            {
                return Horodatage.ToString("dd/MM/yyyy HH:mm:ss") ; // Attention au format Date
            }
            set { }
        }


        [XmlIgnore]
        public decimal Montant { get; set; }

        [XmlElement("Montant")]
        public string Montantstring
        {
            get 
            {
                return Montant.ToString("C", EuroConverter.EuroCulture); ;
            }
            set { }
        }

        [XmlIgnore]
        public int Expediteur { get; set; }
        public string CompteExpediteur
        {
            get
            {
                if (Expediteur == 0)
                { return null; }
                else
                { return Expediteur.ToString(); }
            }
            set { }
        }
        
       
        
        [XmlIgnore]
        public int Destinataire { get; set; }

        public string CompteDestinataire
        {
            get
            {
                if (Destinataire == 0)
                { return null; }
                else
                { return Destinataire.ToString(); }
            }
            set { }
        }

        [XmlIgnore]
      
        public Operation TypeOperation { get; set; }

        [XmlElement("Operation")]
        public string TOperation
        {

            get
            {
                if (TypeOperation == Operation.DepotSimple)
                {
                    return "Dépot";
                }
                else if (TypeOperation == Operation.RetraitSimple)
                {
                    return "Retrait";
                }
                else if (TypeOperation == Operation.InterCompte)
                {
                    return "Virement";
                }
                else
                {
                    return "Indéfini";
                }
            }
            set { }
        }
        public Transaction() { }

        public Transaction(int idTransaction, DateTime horodatage, decimal montant, int expediteur, int destinataire)
        {
            IdTransaction = idTransaction;
            Horodatage = horodatage;
            Montant = montant;
            Expediteur = expediteur;
            Destinataire = destinataire;
        }
    }
}
