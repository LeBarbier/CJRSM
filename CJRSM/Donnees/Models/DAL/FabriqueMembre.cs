using System;

namespace CJRSM.Models.DAL
{
    public class FabriqueMembre
    {
        static public IMembre RetourneMembre(String dossier)
        {
            if (dossier.Length == 7)
                return new Membres();
            else
                return null;
        }
    }
}