using TBanque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace CBBanque
{
    public class CarteB

    {
        public string _CBNumCarte { get; private set; }
        public List <long> _CBNumCpts { get; private set; }
        public List<Transaction> _CBHistorique { get; private set; }
        public decimal _CBplafond { get; private set; }




        public CarteB(string line)
        {
            _CBNumCpts = new List<long>();
            _CBHistorique = new List<Transaction>();


            string[] CB_tab = line.Split(';');
            long test_long;
            if (CB_tab[0].Length == 16 && long.TryParse(CB_tab[0].Substring(0, 8), out test_long) && long.TryParse(CB_tab[0].Substring(8, 8), out test_long))
            {
                if (string.IsNullOrWhiteSpace(CB_tab[1]))
                {
                    _CBNumCarte = CB_tab[0];
                    _CBplafond = 500;

                }
                else
                {
                    decimal plafond;
                    if (decimal.TryParse(CB_tab[1], out plafond))
                    {
                        if (plafond >= 500 && plafond <= 3000)
                        {
                            _CBNumCarte = CB_tab[0];
                            _CBplafond = plafond;
                        }
                    }
                }
            }
            
        }
        public void ajout_transaction(Transaction transaction) 
        {
            _CBHistorique.Add(transaction);
        }
    }
}


