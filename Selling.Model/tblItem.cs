﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selling.Model
{
    public class tblItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tblItemID { get; set; }
        [Key]
        [Column(TypeName="Varchar")]
        [StringLength(13)]
        public string ItemCode { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string ItemName { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int ItemAmount { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Pieces { get; set; }
    }
}
