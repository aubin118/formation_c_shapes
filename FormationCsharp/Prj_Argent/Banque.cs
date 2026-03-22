using CBBanque;
using CptBanque;
using EBanque;
using SBanque;
using System;
using System.Collections.Generic;
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

            /*foreach (KeyValuePair<long, CptB> e in DCpt)
            {
                Console.WriteLine($"{e.Value._CptNumCpt}  {e.Value._CptSolde} ");
            }*/

            entree.Transaction_fichier_open();

            Sortie sortie = new Sortie();

            while (!entree.strT.EndOfStream)
            {

                Transaction tran_actuelle = entree.Transaction_lecture();

                if (tran_actuelle._Numtran != 0)
                {

                    if (tran_actuelle._NumCptExp != (long)0 && tran_actuelle._NumCptDes != (long)0)
                    {
                        if (DCpt.TryGetValue(tran_actuelle._NumCptExp, out CptB cpt_exp) &&
                            DCpt.TryGetValue(tran_actuelle._NumCptDes, out CptB cpt_des) &&
                            DCB.TryGetValue(cpt_exp._CptNumCarte, out CarteB CarteB_exp))
                        {


                            if (cpt_exp._CptTypeCompte == 0 &&
                                cpt_des._CptTypeCompte == 0)
                            {
                                TimeSpan diff_temps = new TimeSpan(10);
                                decimal somme = tran_actuelle._Montant;

                                foreach (Transaction tran in CarteB_exp.CBHistorique)
                                {
                                    if (tran.Date_tran + diff_temps > tran_actuelle.Date_tran)
                                    {
                                        somme += tran._Montant;

                                    }
                                    if (somme > CarteB_exp.CBplafond)
                                    {
                                        break;
                                    }
                                }
                                if (somme < CarteB_exp.CBplafond)
                                {
                                    if (cpt_exp.MAJ_solde((tran_actuelle._Montant * -1)))
                                    {
                                        cpt_des.MAJ_solde(tran_actuelle._Montant);
                                        CarteB_exp.Ajout_transaction(tran_actuelle);
                                        tran_actuelle.TransactionOK();
                                    }
                                    else
                                    {

                                        tran_actuelle.TransactionKO();
                                    }
                                }
                                else
                                {
                                    tran_actuelle.TransactionKO();
                                }
                            }
                            else
                            {

                                if (cpt_exp._CptNumCarte == cpt_des._CptNumCarte)
                                {

                                    if (cpt_exp.MAJ_solde((tran_actuelle._Montant * -1)))
                                    {
                                        cpt_des.MAJ_solde(tran_actuelle._Montant);
                                        CarteB_exp.Ajout_transaction(tran_actuelle);
                                        tran_actuelle.TransactionOK();
                                    }
                                    else
                                    {

                                        tran_actuelle.TransactionKO();
                                    }
                                }
                                else
                                {

                                    tran_actuelle.TransactionKO();
                                }
                            }
                        }

                        else
                        {
                            tran_actuelle.TransactionKO();
                        }
                    }
                    else if (tran_actuelle._NumCptDes == 0) //// retrait
                    {
                        if (DCpt.TryGetValue(tran_actuelle._NumCptExp, out CptB cpt_exp) &&
                            DCB.TryGetValue(cpt_exp._CptNumCarte, out CarteB CarteB_exp))
                        {

                            TimeSpan diff_temps = new TimeSpan(10);
                            decimal somme = tran_actuelle._Montant;

                            foreach (Transaction tran in CarteB_exp.CBHistorique)
                            {
                                if (tran.Date_tran + diff_temps > tran_actuelle.Date_tran)
                                {
                                    somme += tran._Montant;

                                }
                                if (somme > CarteB_exp.CBplafond)
                                {
                                    break;
                                }
                            }
                            if (somme < CarteB_exp.CBplafond)
                            {
                                if (cpt_exp.MAJ_solde((tran_actuelle._Montant * -1)))
                                {
                                    CarteB_exp.Ajout_transaction(tran_actuelle);
                                    tran_actuelle.TransactionOK();
                                }
                                else
                                {
                                    tran_actuelle.TransactionKO();
                                }
                            }
                        }
                        else
                        {
                            tran_actuelle.TransactionKO();
                        }
                    }
                    else  //// Depot
                    {
                        if (DCpt.TryGetValue(tran_actuelle._NumCptDes, out CptB cpt_des))
                        {

                            cpt_des.MAJ_solde(tran_actuelle._Montant);
                            tran_actuelle.TransactionOK();

                        }

                    }
                }
                else
                {
                    tran_actuelle.TransactionKO();
                }
                if (tran_actuelle._Numtran != 0)
                {
                    sortie.Ecriture_status(tran_actuelle._Numtran, tran_actuelle._Status);
                }
            }

            // On évite le code mort
            /*foreach (KeyValuePair<long, CptB> e in DCpt)
            {
                Console.WriteLine($"{e.Value._CptNumCpt}  {e.Value._CptSolde} ");
            }*/
            sortie.Fermer_status();
            entree.Transaction_Fermer();
            Console.WriteLine("fin du traitement");

        }

    }
}
