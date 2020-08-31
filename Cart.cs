using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sample.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItem_Id { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}