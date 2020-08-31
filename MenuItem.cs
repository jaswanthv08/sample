using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sample.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        [Display(Name="Free Delivery")]
        public bool FreeDelivery { get; set; }
        
        public int Price { get; set; }
        public bool Active { get; set; }
        [Display(Name="Date Of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}