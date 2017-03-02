﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJRSM.Models.DAL
{
    public interface IParticipant : IEntite
    {
        new int Id { get; set; }
        int IdMembre { get; set; }
        int IdActivite { get; set; }

        IParticipant Inscription(IParticipant participant, IUnitOfWork contexte);
    }
}
