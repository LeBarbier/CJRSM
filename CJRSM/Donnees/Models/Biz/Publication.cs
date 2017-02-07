using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.Biz
{
    public class Publication
    {
        public int Id;
        public string Titre;
        private string MembreId;
        public string contenu;

        public string getMembreId()
        {
            return MembreId;
        }
        public void setMembreId(string MembreId)
        {
            this.MembreId = MembreId;
        }
    }
}