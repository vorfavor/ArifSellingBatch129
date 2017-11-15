using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Selling.Model
{
    public class DataContext : DbContext
    {
        //set DataContext to be initial of database
        public DataContext() : base("name=SellingContext")
        {
            Database.SetInitializer<DataContext>(null);
        }
        //create properties DbSet TblOfficer
        public DbSet<tblOfficer> TblOfficer { get; set; }
        public DbSet<tblItem> TblItem { get; set; }
        public DbSet<tblSelling> TblSelling { get; set; }
        public DbSet<tblSellingDetail> TblSellingDetail { get; set; }
        public DbSet<MstUser> mstUser { get; set; }
        public DbSet<MstProvince> mstProvince { get; set; }
        public DbSet<MstCity> mstCity { get; set; }
        public DbSet<MstSubDistrict> mstSubDistrict { get; set; }

        //remove pluralizing table name on database 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
