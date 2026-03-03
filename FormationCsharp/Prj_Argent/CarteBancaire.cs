using TBanque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBBanque
{
    public class CarteB

    {
        public string _CBNumCarte { get; private set; }
        public List <long> _CBNumCpts { get; private set; }
        public List<Transaction> _CBHistorique { get; private set; }
        public long _CBplafond { get; private set; }




        public CarteB(string line)
        {
            string[] CB_tab = line.Split(';');
            long test_long;
            if (CB_tab[1].Length == 16 && long.TryParse(CB_tab[1].Substring(0, 8), out test_long) && long.TryParse(CB_tab[1].Substring(8, 8), out test_long))
            {
                if (string.IsNullOrWhiteSpace(CB_tab[1]))
                {
                    _CBNumCarte = CB_tab[1];
                    _CBplafond = 5;

                }
                else
                {
                    int plafond;
                    if (int.TryParse(CB_tab[1], out plafond))
                    {
                        if (plafond >= 5 && plafond <= 30)
                        {
                            _CBNumCarte = CB_tab[1];
                            _CBplafond = plafond;
                        }
                    }
                }
            }
        }

    }
}


