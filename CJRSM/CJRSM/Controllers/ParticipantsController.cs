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

        public ActionResult Details(Participant participantDetails)
        {
            return View(participantDetails);
        }

        public ActionResult Inscriptions()
        {
            return View();
        }

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
