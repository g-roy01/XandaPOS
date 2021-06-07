using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models
{
    public class CustomerMasterVM
    {
        public int cust_id { get; set; }
        public string cust_name { get; set; }
        public string cust_addr { get; set; }
        public string cust_pin { get; set; }
        public string cust_phn { get; set; }
        public string cust_email { get; set; }
    }

     
}