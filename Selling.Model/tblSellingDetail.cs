using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selling.Model
{
    public class tblSellingDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tblSellingDetailID { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(5)]
        public string Invoice { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string ItemCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ItemName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string ItemPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
