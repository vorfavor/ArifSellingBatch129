using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Selling.Repo;

namespace Selling.Web.Controllers
{
    public class AjaxController : Controller
    {
        tblOfficerRepo serviceOfficer = new tblOfficerRepo();
        tblItemRepo serviceItem = new tblItemRepo();
        tblSellingRepo serviceSelling = new tblSellingRepo();
        tblSellingDetailRepo serviceSellingDetail = new tblSellingDetailRepo();

        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }
        // GET DATA OFFICER
        public ActionResult GetListOfficer()
        {
            return PartialView("_GetListOfficer",serviceOfficer.GetAll());
        }
        // ADD DATA OFFICER
        public ActionResult AddDataOfficer()
        {
            return PartialView("_AddDataOfficer");
        }
        // GET DATA ITEM
        public ActionResult GetListItem()
        {
            return PartialView("_GetListItem",serviceItem.GetAll());
        }

        // ADD DATA ITEM
        public ActionResult AddDataItem()
        {
            return PartialView("_AddDataItem");
        }
        //GET DATA SELLING
        public ActionResult GetListSelling()
        {
            return PartialView("_GetListSelling", serviceSelling.GetAll());
        }
        // GET DATA SELLING DETAIL
        public ActionResult GetListSellingDetail()
        {
            return PartialView("_GetListSellingDetail", serviceSellingDetail.GetAll());
        }
        public ActionResult EditDataOfficer(string cd)
        {
            return PartialView("_EditDataOfficer",serviceOfficer.GetById(cd));
        }
    }
}