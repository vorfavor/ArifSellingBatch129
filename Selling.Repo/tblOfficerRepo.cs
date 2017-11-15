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
    public class tblOfficerRepo : iSellingRepo<tblOfficerViewModel>
    {
        private DataContext dataContext = new DataContext();

        public bool Create(tblOfficerViewModel model)
        {
            bool result = true;
            tblOfficer mdlOfficer = new tblOfficer();
            mdlOfficer.OfficerCode = model.OfficerCode;
            mdlOfficer.OfficerName = model.OfficerName;
            mdlOfficer.OfficerPassword = model.OfficerPassword;
            mdlOfficer.OfficerStatus = model.OfficerStatus;

            dataContext.TblOfficer.Add(mdlOfficer);
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
        public bool Update(tblOfficerViewModel model)
        {
            bool result = true;
            tblOfficer mdlOfficer = dataContext.TblOfficer.Where(mdl => mdl.OfficerCode == model.OfficerCode).FirstOrDefault();
            mdlOfficer.OfficerCode = model.OfficerCode;
            mdlOfficer.OfficerName = model.OfficerName;
            mdlOfficer.OfficerPassword = model.OfficerPassword;
            mdlOfficer.OfficerStatus = model.OfficerStatus;

            dataContext.Entry(mdlOfficer).State = EntityState.Modified;
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
            tblOfficer mdlOfficer = dataContext.TblOfficer.Where(mdl => mdl.OfficerCode == cd).FirstOrDefault();
            dataContext.TblOfficer.Remove(mdlOfficer);
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
        public List<tblOfficerViewModel> GetAll()
        {
            List<tblOfficerViewModel> result = new List<tblOfficerViewModel>();
            result = (from officer in dataContext.TblOfficer
                      select new tblOfficerViewModel { 
                      tblOfficerID = officer.tblOfficerID,
                      OfficerCode = officer.OfficerCode,
                      OfficerName = officer.OfficerName,
                      OfficerPassword = officer.OfficerPassword,
                      OfficerStatus = officer.OfficerStatus
                      }).ToList();
            return result;
        }
        public tblOfficerViewModel GetById(string cd)
        {
            tblOfficerViewModel result = new tblOfficerViewModel();
            result = (from officer in dataContext.TblOfficer
                      where officer.OfficerCode == cd
                      select new tblOfficerViewModel
                      {
                          tblOfficerID = officer.tblOfficerID,
                          OfficerCode = officer.OfficerCode,
                          OfficerName = officer.OfficerName,
                          OfficerPassword = officer.OfficerPassword,
                          OfficerStatus = officer.OfficerStatus
                      }).FirstOrDefault();
            return result;
        }
    }
}
