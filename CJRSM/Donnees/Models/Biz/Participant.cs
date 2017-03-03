namespace CJRSM.Models.DAL
{
    public partial class Participant : IParticipant
    {
        // Ajoute un participnt à une activité avant de la sauvegarder dans la base de donnée
        public IParticipant Inscription(IParticipant participant, IUnitOfWork contexte)
        {
            Participant participantModifier = new Participant();
            participantModifier.IdActivite = participant.Id;
            participantModifier.IdMembre = participant.Id;
            contexte.Participant.Update(participantModifier);
            contexte.Participant.Save();
            return participant;
        }
    }
}