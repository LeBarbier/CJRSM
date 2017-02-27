using System.Collections.Generic;

namespace CJRSM.Models.DAL
{
    public partial class TypesJeu : ITypesJeu
    {
        public ITypesJeu AjouterLienTypes(TypesJeu typesJeu, IUnitOfWork contexte)
        {
            TypesJeu nouveauLienTypes = new TypesJeu();
            nouveauLienTypes.IdJeu = typesJeu.IdJeu;
            nouveauLienTypes.IdTypes = typesJeu.IdTypes;
            contexte.TypesJeu.Add(nouveauLienTypes);
            contexte.TypesJeu.Save();
            return typesJeu;
        }

        public void Modifier(ITypesJeu typesJeu, IUnitOfWork contexte)
        {
            //TypesJeu modifier = contexte.Document.Find(document.Id);
            //modifier.Titre = document.Titre;
            //modifier.Auteur = document.Auteur;
            //contexte.Document.Update(modifier);
            //contexte.Document.Save();
        }

        public void Supprimer(ITypesJeu typesJeu, IUnitOfWork contexte)
        {
            //TypesJeu supprimer = contexte.Document.Find(document.Id);
            //contexte.Document.Delete(supprimer.Id);
            //contexte.Document.Save();
        }

        public IEnumerable<Jeu> retourEnumerableJeu()
        {
            
            return null;
        }
    }
}