using Or.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Or.Business
{
    public interface IRequests
    {
        Carte InfosCarte(long numCarte);
        int InfosIdtTrans();
        List<Compte> ListeComptesAssociesCarte(long numCarte);
        List<Compte> ListeComptesDispo(int idtCpt);
        List<Transaction> ListeTransactionsAssociesCarte(long numCarte);
        List<Transaction> ListeTransactionsAssociesCompte(int idtCpt);
        bool EffectuerModificationOperationSimple(Transaction trans, long numCarte);
        bool EffectuerModificationOperationInterCompte(Transaction trans, long numCarteExp, long numCarteDest);
    }
}
