using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models.MasterdataModel
{
    public class WarehouseMasterVM
    {
        public int warehouse_id { get; set; }
        public string warehouse_name { get; set; }
        public string warehouse_address { get; set; }
        public string warehouse_pin { get; set; }
        public string warehouse_phone { get; set; }
        public string warehouse_code { get; set; }
    }
}