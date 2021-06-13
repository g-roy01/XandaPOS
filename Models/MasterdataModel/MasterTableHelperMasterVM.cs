using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models.MasterdataModel
{
    public class MasterTableHelperMasterVM
    {
        public int helper_id { get; set; }
        public string helper_name { get; set; }
        public string helper_link_master_table { get; set; }
        public string helper_details { get; set; }
        public string helper_active { get; set; } //This would be string as we are going to show it as active/deactive. NOTE - Field in DB is bool
    }
}