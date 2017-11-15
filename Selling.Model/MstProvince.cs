using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selling.Model
{
    class MstProvince : SellingData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProvinceName { get; set; }
      
    }
}
