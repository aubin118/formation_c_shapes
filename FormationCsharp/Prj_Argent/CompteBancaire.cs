using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CBBanque;

namespace CptBanque
{
    public enum TypeCompte
    {
        Courant,
        Livret
    }
    public class CptsB
    {
        private Dictionary<long, long> _DictCpt;
        private List <string> _TabNumCarte; 
        private List <TypeCompte> _TabTypeCompte;
        private List <decimal> _TabSolde;

        private static int _nbcompte;
        static CptsB()
        {
            _nbcompte = 0;
        }

        public void Add_cpt_line(string line)
        {
            string num_cpt_txt = line.Substring(0,line.IndexOf(';'));
            line = line.Remove(0, line.IndexOf(';')+1);
            long num_cpt ;

            
            char e;
            int nb_virg = line.Count(v => v == ';');
            ////  virgules faire verif


            if (long.TryParse(num_cpt_txt, out num_cpt))
            {
                if (!_DictCpt.ContainsKey(num_cpt))
                {
                    string num_carte = line.Substring(0, 16);
                    line = line.Remove(0, 17);
                    long test_long;
                  if (long.TryParse(line.Substring(0, 8), out test_long) && long.TryParse(line.Substring(8, 8), out test_long))
                    {
                        if (line.Substring(0, 7) == "Courant" || line.Substring(0, 6) == "Livret") 
                        {
                            
                            
                            string solde_txt = line.Substring(line.LastIndexOf(';')+1, line.Length - line.LastIndexOf(';') + 1);
                            decimal solde;
                            if (decimal.TryParse(solde_txt, out solde))
                            {

                                if (line.Substring(0, 7) == "Courant")
                                {
                                    _TabTypeCompte.Add(TypeCompte.Courant);
                                }
                                else
                                {
                                    _TabTypeCompte.Add(TypeCompte.Livret);
                                }
                                _TabSolde.Add(solde);
                                _TabNumCarte.Add(num_carte);
                                _DictCpt.Add(num_cpt, _nbcompte);
                                _nbcompte++;
                            }

                        }
                    }





                    
                    
                } }

        }


    }
    public class cpt 
    {
        public int identifiant { get; private set; }
        public int NumCarte { get; private set; }
        public TypeCompte TypeCpt { get; private set; }
        public double Solde { get; private set; }

    }
}
