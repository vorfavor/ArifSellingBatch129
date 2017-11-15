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
    public class MstUserRepo 
    {
        private DataContext dataContext = new DataContext();

        public List<MstUserViewModel> GetAll(MstUserViewModel dataLogin)
        {
            List<MstUserViewModel> result = new List<MstUserViewModel>();
            result = (from user in dataContext.mstUser
                      join officer in dataContext.TblOfficer
                          on user.OfficerCode equals officer.OfficerCode
                          where user.Username == dataLogin.Username 
                          && user.Password == dataLogin.Password
                      select new MstUserViewModel
                      {
                          Id = user.Id,
                          Username = user.Username,
                          Password = user.Password,
                          Active = user.Active,
                          OfficerCode = user.OfficerCode,
                          OfficerName = officer.OfficerName
                      }).ToList();
            return result;
        }
    }
}
