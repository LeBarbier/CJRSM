﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJRSM.Models.DAL
{
    public interface IActivite : IEntite
    {
        new int Id { get; set; }
        string Titre { get; set; }
        string Description { get; set; }
        Nullable<int> NbrMembreMin { get; set; }
        Nullable<int> NbrMembreMax { get; set; }
        int Jour { get; set; }
        System.TimeSpan HeureDebut { get; set; }
        System.DateTime DateDebut { get; set; }
        Nullable<int> NbrRepetion { get; set; }
        bool Accepte { get; set; }
        string IdActiviteJeu { get; set; }

        Activite Ajout(Activite nouvelleActivite, IUnitOfWork contexte);
    }
}
