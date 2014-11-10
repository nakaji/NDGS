using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGDS.Web.Models;

namespace NGDS.Web.ViewModels
{
    public class StocksAddViewModel
    {
        public List<SelectListItem> Drinks { get; set; }

        [DisplayName("銘柄")]
        public int DrinkId { get; set; }

        [DisplayName("本数")]
        public int Amount { get; set; }

        public StocksAddViewModel()
        {
            Drinks = new List<SelectListItem>();
        }
    }

    public class StocksEditViewModel
    {
        [DisplayName("銘柄")]
        public List<SelectListItem> Drinks { get; set; }

        public Stock Stock { get; set; }

        public StocksEditViewModel()
        {
            Drinks = new List<SelectListItem>();
        }
    }
}