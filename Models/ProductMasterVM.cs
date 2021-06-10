using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models
{
    public class ProductMasterVM
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int? product_type_id { get; set; }
        public string product_type_name { get; set; }
        public int? product_group_id { get; set; }
        public string product_group_name { get; set; }
        public int? product_company_id { get; set; }
        public string product_company_name { get; set; }
        public string product_details { get; set; }
        public string product_image_link { get; set; }
    }
}