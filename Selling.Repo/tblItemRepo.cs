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
    public class tblItemRepo : iSellingRepo<tblItemViewModel>
    {
        private DataContext dataContext = new DataContext();

        public bool Create(tblItemViewModel model) {
            bool result = true;
            tblItem mdlItem = new tblItem();
            mdlItem.ItemCode = model.ItemCode;
            mdlItem.ItemName = model.ItemName;
            mdlItem.ItemAmount = model.ItemAmount;
            mdlItem.BuyingPrice = model.BuyingPrice;
            mdlItem.SellingPrice = model.SellingPrice;
            mdlItem.Pieces = model.Pieces;

            dataContext.TblItem.Add(mdlItem);
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
        public bool Update(tblItemViewModel model)
        {
            bool result = true;
            tblItem mdlItem = dataContext.TblItem.Where(mdl => mdl.ItemCode == model.ItemCode).FirstOrDefault();
            mdlItem.ItemCode = model.ItemCode;
            mdlItem.ItemName = model.ItemName;
            mdlItem.ItemAmount = model.ItemAmount;
            mdlItem.BuyingPrice = model.BuyingPrice;
            mdlItem.SellingPrice = model.SellingPrice;
            mdlItem.Pieces = model.Pieces;

            dataContext.Entry(mdlItem).State = EntityState.Modified;
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
        public bool Delete(string cd)
        {
            bool result = true;
            tblItem mdlItem = dataContext.TblItem.Where(mdl => mdl.ItemCode == cd).FirstOrDefault();
            dataContext.TblItem.Remove(mdlItem);
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
        public List<tblItemViewModel> GetAll()
        {
            List<tblItemViewModel> result = new List<tblItemViewModel>();
            result = (from item in dataContext.TblItem
                      select new tblItemViewModel
                      {
                        tblItemID = item.tblItemID,
                        ItemCode = item.ItemCode,
                        ItemName = item.ItemName,
                        BuyingPrice = item.BuyingPrice,
                        SellingPrice = item.SellingPrice,
                        ItemAmount = item.ItemAmount,
                        Pieces = item.Pieces
                      }).ToList();
            return result;
        }
        public tblItemViewModel GetById(string cd)
        {
            tblItemViewModel result = new tblItemViewModel();
            result = (from item in dataContext.TblItem
                      select new tblItemViewModel
                      {
                          tblItemID = item.tblItemID,
                          ItemCode = item.ItemCode,
                          ItemName = item.ItemName,
                          BuyingPrice = item.BuyingPrice,
                          SellingPrice = item.SellingPrice,
                          ItemAmount = item.ItemAmount,
                          Pieces = item.Pieces
                      }).FirstOrDefault();
            return result;
        }
    }
}
