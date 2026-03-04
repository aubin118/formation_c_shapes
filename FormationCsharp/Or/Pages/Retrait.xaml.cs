using Or.Business;
using Or.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Retrait.xaml
    /// </summary>
    public partial class Retrait : PageFunction<long>
    {
        private readonly IRequests _requests;

        Carte CartePorteur { get; set; }
        Compte ComptePorteur { get; set; }
        public Retrait(long numCarte, IRequests requests)
        {
            _requests = requests;
            InitializeComponent();
            Montant.Text = 0M.ToString("C2");

            CartePorteur = _requests.InfosCarte(numCarte);
            ComptePorteur = _requests.ListeComptesAssociesCarte(CartePorteur.Id).Find(x => x.TypeDuCompte == TypeCompte.Courant);
            List<Transaction> transac = _requests.ListeTransactionsAssociesCarte(numCarte);
            List<int> cpts = _requests.ListeComptesAssociesCarte(numCarte).Select(x => x.Id).ToList();
            CartePorteur.AlimenterHistoriqueEtListeComptes(transac, cpts);

            PlafondReelRetrait.Text = SoldeCarteActuel();
            PlafondMaxRetrait.Text = CartePorteur.Plafond.ToString("C2");
            Solde.Text = ComptePorteur.Solde.ToString("C2");
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void ValiderRetrait_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(Montant.Text.Replace(".", ",").Trim(new char[] { '€', ' ' }), out decimal montant) && montant > 0)
            {
                //Compte fictif pour permettre la transaction
                Compte compteBanque = new Compte(0, 0, TypeCompte.Courant, 0);
                Transaction t = new Transaction(0, DateTime.Now, montant, ComptePorteur.Id, compteBanque.Id);

                if (CartePorteur.EstRetraitAutoriseNiveauCarte(t, compteBanque, ComptePorteur) && ComptePorteur.EstRetraitValide(t))
                {
                    _requests.EffectuerModificationOperationSimple(t, CartePorteur.Id);

                    OnReturn(null);
                }
                else
                {
                    MessageBox.Show("Opération de retrait non authorisée");
                }
            }
            else
            {
                MessageBox.Show("Montant invalide");
            }
        }
        private string SoldeCarteActuel() 
        {
            List<Transaction> retraitsHisto = CartePorteur.Historique.Where(x => (x.Horodatage > DateTime.Now.AddDays(-10)) && CartePorteur.ListComptesId.Contains(x.Expediteur)).Select(x => x).ToList();
            decimal sommeHisto = retraitsHisto.Sum(x => x.Montant);
            return (CartePorteur.Plafond - sommeHisto).ToString("C2");
        }
    }
}
