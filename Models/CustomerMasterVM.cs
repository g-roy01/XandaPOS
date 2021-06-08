using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XandaPOS.Models
{
    public class CustomerMasterVM
    {
        [Key]
        public int cust_id { get; set; }
        public string cust_name { get; set; }
        public string cust_addr { get; set; }
        public string cust_pin { get; set; }
        public string cust_phn { get; set; }
        public string cust_email { get; set; }
    }


    //Added DB context class
    //public class CustomerMasterDbContextVM : DbContext
    //{
    //    public DbSet<CustomerMasterVM> CustomerData { get; set; }
    //}
}