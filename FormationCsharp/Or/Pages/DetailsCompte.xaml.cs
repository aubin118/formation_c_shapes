using Or.Business;
using Or.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour DetailsCompte.xaml
    /// </summary>
    public partial class DetailsCompte : PageFunction<Int64>
    {
        private readonly IRequests _requests;

        public DetailsCompte(long numCarte, int compte, IRequests requests)
        {
            _requests = requests;
            InitializeComponent();

            Compte c = _requests.ListeComptesAssociesCarte(numCarte).Find(x => x.Id == compte);

            IdCompte.Text = c.Id.ToString();
            TypeCompte.Text = c.TypeDuCompte.ToString();
            Solde.Text = c.Solde.ToString("C2");

            List<Transaction> transactions = _requests.ListeTransactionsAssociesCompte(compte);

            // - si opération de débit, + si opération de crédit
            transactions.ForEach(x => x.Montant = x.Expediteur == c.Id ? -x.Montant : x.Montant);

            listView.ItemsSource = transactions;

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridView gridView = listView.View as GridView;
            if (gridView != null)
            {
                double totalWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
                gridView.Columns[0].Width = totalWidth * 0.10; // 10%
                gridView.Columns[1].Width = totalWidth * 0.45; // 40%
                gridView.Columns[2].Width = totalWidth * 0.45; // 20%
            }
        }
    }
}
