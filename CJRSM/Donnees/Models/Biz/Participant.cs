namespace CJRSM.Models.DAL
{
    public partial class Participant : IParticipant
    {
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