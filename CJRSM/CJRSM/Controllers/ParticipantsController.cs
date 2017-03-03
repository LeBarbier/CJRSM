using System.Web.Mvc;
using CJRSM.Models.DAL;

namespace CJRSM.Controllers
{
    public class ParticipantsController : Controller
    {
        private IGenericRepository<Participant> repo;
        private IUnitOfWork contexte;
        Participant participant;

        public ParticipantsController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Participant;
        }

        public ParticipantsController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Participant;
        }

        // Retourne la vu details avec les informations du particpant selectionnées
        public ActionResult Details(Participant participantDetails)
        {
            return View(participantDetails);
        }

        // Retourne la vue inscriptions
        public ActionResult Inscriptions()
        {
            return View();
        }

        // Retourne la vue details après avoir ajouté un membre à une activité comme participant
        [HttpPost]
        public ActionResult Inscriptions(Participant participantInscription)
        {
            if (ModelState.IsValid)
            {
                participant = new Participant();
                return RedirectToAction("details", participant.Inscription(participantInscription, contexte));
            }
            else
                return View(participant);
        }
    }
}
