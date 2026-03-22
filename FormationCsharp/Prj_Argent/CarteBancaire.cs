using TBanque;
using System.Collections.Generic;
using System.Linq;

namespace CBBanque
{
    public class CarteB

    {
        // Bonne pratique - les propriétés en lecture seule en dehors de l'instance
        public string CBNumCarte { get; private set; }
        public List <long> CBNumCpts { get; private set; }
        public List<Transaction> CBHistorique { get; private set; }
        public decimal CBplafond { get; private set; }

        public CarteB(string line)
        {
            CBNumCpts = new List<long>();
            CBHistorique = new List<Transaction>();


            string[] CB_tab = line.Split(';');
            long test_long;
            // Compliqué, non - tu ne peux pas utiliser ?
            // bool allDigits = !string.IsNullOrEmpty(CB_tab[0]) && CB_tab[0].All(char.IsDigit);
            if (CB_tab[0].Length == 16 && long.TryParse(CB_tab[0].Substring(0, 8), out test_long) && long.TryParse(CB_tab[0].Substring(8, 8), out test_long))
            {
                if (string.IsNullOrWhiteSpace(CB_tab[1]))
                {
                    CBNumCarte = CB_tab[0];
                    CBplafond = 500;
                }
                else
                {
                    decimal plafond;
                    if (decimal.TryParse(CB_tab[1], out plafond))
                    {
                        if (plafond >= 500 && plafond <= 3000)
                        {
                            CBNumCarte = CB_tab[0];
                            CBplafond = plafond;
                        }
                    }
                }
            }
            
        }
        public void Ajout_transaction(Transaction transaction) 
        {
            CBHistorique.Add(transaction);
        }
    }
}


