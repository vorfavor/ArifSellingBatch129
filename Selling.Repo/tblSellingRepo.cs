using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selling.Model;
using Selling.ViewModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Selling.Repo
{
    public class tblSellingRepo : iSellingRepo<tblSellingViewModel>
    {
        private DataContext dataContext = new DataContext();

        public bool Create(tblSellingViewModel model) {
            bool result = true;
            return result;
        }
        public bool Update(tblSellingViewModel model)
        {
            bool result = true;
            return result;
        }
        public bool Delete(string cd)
        {
            bool result = true;
            tblSelling mdlSelling = dataContext.TblSelling.Where(mdl => mdl.Invoice == cd).FirstOrDefault();
            dataContext.TblSelling.Remove(mdlSelling);
            try
            {
                dataContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                result = false;
                return result;
            }
        }
        public List<tblSellingViewModel> GetAll()
        {
            List<tblSellingViewModel> result = new List<tblSellingViewModel>();
            result = (from selling in dataContext.TblSelling
                      select new tblSellingViewModel
                      {
                          tblSellingID = selling.tblSellingID,
                          Invoice = selling.Invoice,
                          InvoiceDate = selling.InvoiceDate,
                          Item = selling.Item,
                          Total = selling.Total,
                          Paid = selling.Paid,
                          Return = selling.Return,
                          OfficerCode = selling.OfficerCode
                      }).ToList();
            return result;
        }
        public tblSellingViewModel GetById(string cd)
        {
            tblSellingViewModel result = new tblSellingViewModel();
            result = (from selling in dataContext.TblSelling
                      select new tblSellingViewModel
                      {
                          tblSellingID = selling.tblSellingID,
                          Invoice = selling.Invoice,
                          InvoiceDate = selling.InvoiceDate,
                          Item = selling.Item,
                          Total = selling.Total,
                          Paid = selling.Paid,
                          Return = selling.Return,
                          OfficerCode = selling.OfficerCode
                      }).FirstOrDefault();
            return result;
        }
    }
}
