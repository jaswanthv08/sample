using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sample.Models;
namespace sample.ViewModels
{
    public class CreateViewModel
    {
        public List<Category>Categories{get;set;}
        public MenuItem MenuItem { get; set; }
    }
}