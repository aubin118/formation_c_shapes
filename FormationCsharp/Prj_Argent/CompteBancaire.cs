namespace CptBanque
{
    public enum TypeCompte
    {
        Courant = 0,
        Livret = 1
    }
    public class CptB
    {
        public long _CptNumCpt { get; private set; }
        public string _CptNumCarte { get; private set; }
        public TypeCompte _CptTypeCompte { get; private set; }
        public decimal _CptSolde { get; private set; }


        public CptB(string line)
        {

            string[] cpt_tab = line.Split(';');

            long num_cpt;


            if (cpt_tab.Length == 4 && long.TryParse(cpt_tab[0], out num_cpt))
            {
                long test_long;
                if (cpt_tab[1].Length == 16 && long.TryParse(cpt_tab[1].Substring(0, 8), out test_long) && long.TryParse(cpt_tab[1].Substring(8, 8), out test_long))
                {
                    if (cpt_tab[2] == "Courant" || cpt_tab[2] == "Livret")
                    {
                        decimal solde;

                        // Test pour le solde
                        if (!string.IsNullOrWhiteSpace(cpt_tab[3]))
                        {

                            cpt_tab[3] = cpt_tab[3].Replace('.', ',');

                            if (decimal.TryParse(cpt_tab[3], out solde))
                            {

                                if (cpt_tab[2] == "Courant")
                                {
                                    _CptTypeCompte = TypeCompte.Courant;
                                }
                                else
                                {
                                    _CptTypeCompte = TypeCompte.Livret;
                                }
                                _CptSolde = solde;
                                _CptNumCarte = cpt_tab[1];
                                _CptNumCpt = num_cpt;

                            }
                        }
                        else
                        {

                            solde = 0;

                            // Duplication de code, tu pourrais refactoriser
                            if (cpt_tab[2] == "Courant")
                            {
                                _CptTypeCompte = TypeCompte.Courant;
                            }
                            else
                            {
                                _CptTypeCompte = TypeCompte.Livret;
                            }
                            _CptSolde = solde;
                            _CptNumCarte = cpt_tab[1];
                            _CptNumCpt = num_cpt;
                        }
                    }
                }

            }
        }

        public bool MAJ_solde(decimal montant)
        {
            // Bien
            if (_CptSolde + montant < 0)
            {
                return false;
            }
            else
            {
                _CptSolde += montant;
                return true;
            }
        }
    }

}
