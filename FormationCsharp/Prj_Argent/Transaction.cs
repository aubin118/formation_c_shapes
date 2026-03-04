using CptBanque;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TBanque
{
    public enum Status
    {
        OK,
        KO
    }
    public class Transaction
    {
        public static readonly List<long> liste_tran = new List<long>();
        public long _Numtran { get; private set; }
        public DateTime Date_tran { get; private set; }
        public decimal _Montant { get; private set; }
        public long _NumCptExp { get; private set; }
        public long _NumCptDes { get; private set; }
        public Status _Status { get; private set; }

        public Transaction(string line)
        {
            string[] tran_tab = line.Split(';');

            long num_tran;


            if (tran_tab.Length == 5 && long.TryParse(tran_tab[0], out num_tran))
            {

                if (!liste_tran.Exists(v => v == num_tran))
                {
                    
                    DateTime date_tran;
                    
                    if (DateTime.TryParse(tran_tab[1], out date_tran))
                    {
                        
                        decimal montant;
                        tran_tab[2] = tran_tab[2].Replace('.', ',');
                        

                        if (decimal.TryParse(tran_tab[2], out montant))
                        {
                            
                            long num_cpt_exp;
                            long num_cpt_des;
                            if (long.TryParse(tran_tab[3], out num_cpt_exp) && long.TryParse(tran_tab[4], out num_cpt_des) && num_cpt_exp != num_cpt_des)
                            {
                                _Numtran = num_tran;
                                liste_tran.Add(num_tran);
                                Date_tran = date_tran;
                                _Montant = montant;
                                _NumCptExp = num_cpt_exp;
                                _NumCptDes = num_cpt_des;
                            }
                        }

                    }
                }
            }
        }
        public void TransactionOK()
        {
            _Status = Status.OK;
        }
        public void TransactionKO()
        {
            _Status = Status.KO;
        }
    }
}

