using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models
{
    public class MasterTableHelperMasterVM
    {
        public int helper_id { get; set; }
        public string helper_name { get; set; }
        public string helper_link_master_table { get; set; }
        public string helper_details { get; set; }
        public bool helper_active { get; set; }
    }
}