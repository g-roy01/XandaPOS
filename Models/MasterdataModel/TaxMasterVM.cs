using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models.MasterdataModel
{
    public class TaxMasterVM
    {
        public int tax_id { get; set; }
        public string tax_name { get; set; }
        public string tax_description { get; set; }
        public decimal tax_percent { get; set; }
        public bool tax_active_status { get; set; }
    }
}