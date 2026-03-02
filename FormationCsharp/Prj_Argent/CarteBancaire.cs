using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBBanque
{
    public class CarteB

    {
        private Dictionary<string, int> _cartes;
        
        public void Add_carte_line(string line)
        {
            string num_carte = line.Substring(0, 16);
            long test_long;
            if (!_cartes.ContainsKey(num_carte) && long.TryParse(line.Substring(0, 8), out test_long) && long.TryParse(line.Substring(8, 8), out test_long))
            {
                if (line.Length == 15)
                {
                    _cartes.Add(num_carte, 5);

                }
                else
                {
                    int plafond;
                    if (int.TryParse(line.Remove(0, 17), out plafond))
                    {
                        if (plafond >= 5 && plafond <= 30)
                        {
                            _cartes.Add(num_carte, plafond);
                        }
                    }
                }
            }
        }

    }
}


