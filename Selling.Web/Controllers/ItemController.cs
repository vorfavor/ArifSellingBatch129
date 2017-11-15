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
    public class ItemController : Controller
    {
        tblItemRepo serviceItem = new tblItemRepo();
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                string sp = "spomaxiditem";
                DataSet data = Commonly.Common.ExecuteDataSet(sp);
                int id = data.Tables[0].Rows[0].Field<int>("MaxID");
                model.tblItemID = id;
                if (serviceItem.Create(model))
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
        [HttpPost]
        public ActionResult Update(tblItemViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (serviceItem.Update(model))
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
        public ActionResult Delete(string cd)
        {
            if (ModelState.IsValid)
            {
                if (serviceItem.Delete(cd))
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