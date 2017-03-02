using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public partial class Participant : IParticipant
    {
        public IParticipant Inscription(IParticipant participant, IUnitOfWork contexte)
        {
            Participant participantModifier = new Participant();
            participantModifier.IdActivite = participant.Id;
            participantModifier.IdMembre = participant.Id;
            //participantModifier.Membre = contexte.Membre.Get(m => m.Id.Equals(participant.IdMembre));
            //participantModifier.Activite = participant;
            contexte.Participant.Update(participantModifier);
            contexte.Participant.Save();
            return participant;
        }
    }
}