using CBBanque;
using CptBanque;
using EBanque;
using SBanque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBanque;

namespace Prj_Argent
{
    public class Banque
    {

        public Banque()
        {

            Entree entree = new Entree();
            Dictionary<string, CarteB> DCB = new Dictionary<string, CarteB>();
            Dictionary<long, CptB> DCpt = new Dictionary<long, CptB>();


            DCB = entree.CB_fichier();
            DCpt = entree.Cpt_fichier();

            entree.Transaction_fichier_open();

            Sortie sortie = new Sortie();

            while (!entree.strT.EndOfStream)
            {
                Transaction tran_actuelle = entree.Transaction_lecture();
                if (tran_actuelle._Numtran != 0)
                {
                    if (tran_actuelle._NumCptExp != 0 && tran_actuelle._NumCptDes != 0)
                    {
                        if (DCpt.TryGetValue(tran_actuelle._NumCptExp, out CptB cpt_exp) &&
                            DCpt.TryGetValue(tran_actuelle._NumCptDes, out CptB cpt_des) &&
                            DCB.TryGetValue(cpt_des._CptNumCarte, out CarteB CarteB_exp))
                        {
                            if (cpt_exp._CptTypeCompte == TypeCompte.Courant &&
                                cpt_des._CptTypeCompte == TypeCompte.Courant)
                            {

                            }
                            else
                            {
                                if (cpt_exp._CptNumCarte == cpt_des._CptNumCarte)
                                {

                                }
                            }

                        }
                    }
                    else if (tran_actuelle._NumCptExp == 0) //// retrait
                    {
                        
                    }
                    else  //// Depot
                    {

                    }

                    
                }
            }
        }

    }
}
