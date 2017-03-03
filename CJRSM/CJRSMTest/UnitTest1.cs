using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using CJRSM.Controllers;
using System.Web.Mvc;
using CJRSM.Models.DAL;

namespace CJRSMTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestActiviteControllerIndex()
        {
            var activiteController = new ActiviteController();
            ViewResult resultat = activiteController.Index("") as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestActiviteControllerDetails()
        {
            var activiteController = new ActiviteController();
            ViewResult resultat = activiteController.Details(2) as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestDocumentControllerIndex()
        {
            var documentController = new DocumentController();
            var resultat = documentController.Index("", "", 0) as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestDocumentControllerDetails()
        {
            var documentController = new DocumentController();
            var resultat = documentController.Modifier(1) as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestHomeControllerIndex()
        {
            var homeController = new HomeController();
            var resultat = homeController.Index() as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestHomeControllerDetails()
        {
            var homeController = new HomeController();
            var resultat = homeController.Details(1) as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestMembreControllerConnexion()
        {
            var membreController = new MembreController();
            var resultat = membreController.Connexion() as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestMembreControllerAjoutDocument()
        {
            var membreController = new MembreController();
            var resultat = membreController.AjoutDocument() as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestParticipantsControllerIndex()
        {
            var activiteController = new ActiviteController();
            var resultat = activiteController.Details(1) as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestParticipantsControllerInscriptions()
        {
            var participantController = new ParticipantsController();
            var resultat = participantController.Inscriptions() as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestTypesJeuControllerIndex()
        {
            var typesJeuController = new TypesJeuController();
            var resultat = typesJeuController.Ajout() as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestJeuControllerIndex()
        {
            var jeuController = new JeuController();
            var resultat = jeuController.Index("") as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
        [TestMethod]
        public void TestJeuControllerModifier()
        {
            var jeuController = new JeuController();
            var resultat = jeuController.Modifier(1) as ViewResult;
            Assert.AreEqual("", resultat.ViewName);
        }
    }
}
