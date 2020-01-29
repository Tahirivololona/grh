using GRH_BO.Dto.User;
using GRH_BO.Entities;
using GRH_BO.Utilities;
using GRH_BS.User;
using GRH_UI.Models.Administration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRH_UI.Controllers
{
    public class AdministrationController : Controller
    {

        private readonly IBaseService _userService;

        public AdministrationController(IBaseService userService)
        {
            _userService = new BaseService();
        }

        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Administration(AdministrationViewModel model)
        {
            if (model == null)
            {
                model = new AdministrationViewModel();
            }
            model.ListUser = _userService.ListUserForTable();
            model.ListProfil = _userService.ListProfil();
            model.ListAcces = _userService.ListAcces();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(AdministrationViewModel model)
        {
            if(!ModelState.IsValid)
            {
                Trace.WriteLine("TAFIDITRA ATO : FORMULAIRE INVALIDE");
                ViewBag.ErrorMessage = "Formulaire Invalide";
                return RedirectToAction("Administration", "Administration");
            }
            try
            {
                Trace.WriteLine("TAFIDITRA ATO : MANDE TSARA");
                var user = new USER
                {
                    NOMUSER = model.Nom,
                    PRENOMUSER = model.Prenom,
                    LOGINUSER = model.Login,
                    MDP = Utilities.GetHashString(model.Password),
                    EMAIL = model.Email,
                    TELINSCRIPTION = model.Telephone,
                    IDPROFIL = model.Profil,
                    DATEPROFIL = DateTime.Now,
                };
                _userService.InsertUser(user);
                return RedirectToAction("Administration");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("TAFIDITRA ATO : MISY ERREUR :"+ex.InnerException);
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Administration", "Administration");
            }
        }

        public ActionResult AdminHistorique()
        {
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            try
            {
                Trace.WriteLine("TAFIDITRA ATO : MANDE TSARA");
                _userService.DeleteUser(id);
                return RedirectToAction("Administration");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("TAFIDITRA ATO : MISY ERREUR :" + ex.InnerException);
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Administration", "Administration");
            }
        }
    }
}