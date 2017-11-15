using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selling.Repo
{
    public interface iSellingRepo<Sellings>
    {
        //create CRUD for Selling.Repo
        bool Create(Sellings model);
        bool Update(Sellings model);
        bool Delete(string cd);
        List<Sellings> GetAll();
        Sellings GetById(string cd);
    }
}
