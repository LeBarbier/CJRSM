﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public class Documents
    {
        public int Id;
        public string Titre;
        public string Auteur;
        public bool Disponible;
        public DateTime DateAjout;
        public string MembreId;

        Documents(int id, string titre, string auteur)
        {
            this.Id = id;
            this.Titre = titre;
            this.Auteur = auteur;
            this.Disponible = true;
            this.DateAjout = DateTime.Today;
        }

        public string getMembreId()
        {
            return MembreId;
        }
        public void setMembreId(string  MembreId)
        {
            this.MembreId = MembreId;
        }
        public void Emprunt(string membreId)
        {
            this.Disponible = false;
            this.MembreId = membreId;
        }
        /*public ArrayList getDocument()
        {
            return this;
        }*/
    }
}