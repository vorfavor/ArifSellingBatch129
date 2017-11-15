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
    public class tblSellingDetailRepo : iSellingRepo<tblSellingDetailViewModel>
    {
        private DataContext dataContext = new DataContext();

        public bool Create(tblSellingDetailViewModel model) {
            bool asd = true;
            return asd;
        }
        public bool Update(tblSellingDetailViewModel model)
        {
            bool result = true;
            return result;
        }
        public bool Delete(string cd)
        {
            bool result = true;
            return result;
        }
        public List<tblSellingDetailViewModel> GetAll()
        {
            List<tblSellingDetailViewModel> result = new List<tblSellingDetailViewModel>();
            result = (from sellingdetail in dataContext.TblSellingDetail
                      select new tblSellingDetailViewModel
                      {
                         tblSellingDetailID = sellingdetail.tblSellingDetailID,
                         Invoice = sellingdetail.Invoice,
                         ItemCode = sellingdetail.ItemCode,
                         ItemName = sellingdetail.ItemName,
                         ItemPrice = sellingdetail.ItemPrice,
                         SubTotal = sellingdetail.SubTotal
                      }).ToList();
            return result;
        }
        public tblSellingDetailViewModel GetById(string cd)
        {
            tblSellingDetailViewModel result = new tblSellingDetailViewModel();
            return result;
        }
    }
}
