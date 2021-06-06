using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models
{
    public class ProductMasterVM
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string product_type { get; set; }
        public string product_group { get; set; }
        public string product_company { get; set; }
        public string product_details { get; set; }
        public string product_image_link { get; set; }
    }
}