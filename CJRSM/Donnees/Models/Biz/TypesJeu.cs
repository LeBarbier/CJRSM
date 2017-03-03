using System.Collections.Generic;

namespace CJRSM.Models.DAL
{
    public partial class TypesJeu : ITypesJeu
    {
        // Ajoute le nouveau lien entre type et jeu à la base de donnée
        public ITypesJeu AjouterLienTypes(TypesJeu typesJeu, IUnitOfWork contexte)
        {
            TypesJeu nouveauLienTypes = new TypesJeu();
            nouveauLienTypes.IdJeu = typesJeu.IdJeu;
            nouveauLienTypes.IdTypes = typesJeu.IdTypes;
            contexte.TypesJeu.Add(nouveauLienTypes);
            contexte.TypesJeu.Save();
            return typesJeu;
        }
    }
}