using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Selling.ViewModel;
using Selling.Repo;
using Selling.Commonly;

namespace Selling.Web.Controllers
{
    public class OfficerController : Controller
    {
        tblOfficerRepo serviceOfficer = new tblOfficerRepo();
        // GET: Officer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblOfficerViewModel model)
        {
            if (ModelState.IsValid)
            {
                string sp = "spomaxidofficer";
                DataSet data = Commonly.Common.ExecuteDataSet(sp);
                int id = data.Tables[0].Rows[0].Field<int>("MaxID");
                model.tblOfficerID = id;
                if (serviceOfficer.Create(model))
                {
                    return Json(new {pesan = "sukses"},JsonRequestBehavior.AllowGet);
                }
                else
	            {
                     return Json(new{pesan = "gagal"},JsonRequestBehavior.AllowGet);
	            }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update(tblOfficerViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (serviceOfficer.Update(model))
                {
                     return Json(new {pesan = "sukses"},JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { pesan = "gagal" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
        public ActionResult Delete(string cd)
        {
            if (ModelState.IsValid)
            {
                if (serviceOfficer.Delete(cd))
                {
                    return Json(new { pesan = "sukses" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { pesan = "gagal" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
    }
}