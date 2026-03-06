using Or.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Or.Business
{
    [XmlRoot("Comptes")]
    public class Export_compte
    {
        /*[XmlArray("Comptes")]
        [XmlArrayItem("Compte", typeof(ExportCompteTransactions))]*/
        [XmlElement("Compte")]
        public List<ExportCompteTransactions> ListeCompte { get; set; }

        public Export_compte()
        {
        }

        public Export_compte(long NumCarte, IRequests requests)
        {
            ListeCompte = new List<ExportCompteTransactions>();
            List <Compte> Lcompte = requests.ListeComptesAssociesCarte(NumCarte);
            foreach (Compte compte in Lcompte)
            {
                ListeCompte.Add(new ExportCompteTransactions(compte, requests));
            }
        }
    }
    public class ExportCompteTransactions 
    {
        [XmlElement("Identifiant", Order = 1) ]
        public int Id { get; set; }

        [XmlIgnore]
        public TypeCompte TypeDuCompte { get; set; }


        [XmlElement("Type", Order = 2)]
        public string TCompte
        {

            get
            {
                if (TypeDuCompte == TypeCompte.Courant)
                {
                    return "Courant";
                }
                else if (TypeDuCompte == TypeCompte.Livret)
                {
                    return "Livret";
                }
                else
                {
                    return "Indéfini";
                }
            }
            set { }
        }


        [XmlIgnore]
        public decimal Solde { get; private set; }
        [XmlElement("Solde", Order = 3)]
        public string SSolde
        {
            get
            {
                return Solde.ToString("C", EuroConverter.EuroCulture); ;
            }
            set { }
        }



        [XmlArray("Transactions", Order = 4)]
        [XmlArrayItem("Transaction", typeof(Transaction))]
        public List<Transaction> ListeTransactions { get; set; }

        public ExportCompteTransactions()
        { }


        public ExportCompteTransactions(Compte compte, IRequests requests) 
        {
            Id = compte.Id;
            TypeDuCompte = compte.TypeDuCompte;
            Solde = compte.Solde;
            ListeTransactions = new List<Transaction>();
            List<Transaction> transactions = requests.ListeTransactionsAssociesCompte(compte.Id);
            for (int i = 0; i < transactions.Count; i++)
            {
                transactions[i].TypeOperation = Tools.TypeTransaction(transactions[i].Expediteur, transactions[i].Destinataire);
            }
            for (int i = 0; i < transactions.Count & i < 10; i++)
            {
                ListeTransactions.Add(transactions[i]);
            }
        }
    }
}
