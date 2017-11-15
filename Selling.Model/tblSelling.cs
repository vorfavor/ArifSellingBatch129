using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selling.Model
{
    public class tblSelling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tblSellingID { get; set; }
        [Key]
        [Column(TypeName="Varchar")]
        [StringLength(5)]
        public string Invoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Item { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Return { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(5)]
        public string OfficerCode { get; set; }
    }
}
