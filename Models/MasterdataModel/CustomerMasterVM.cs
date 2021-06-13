using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using XandaPOS.Edmx;

namespace XandaPOS.Models.MasterdataModel
{
    public class CustomerMasterVM
    {
        [Key]
        //[Key, Column(Order = 1)]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int cust_id { get; set; }
        public string cust_name { get; set; }
        public string cust_addr { get; set; }
        public string cust_pin { get; set; }
        public string cust_phn { get; set; }
        public string cust_email { get; set; }
    }

    //public class CustomerDbContext : DbContext
    //{
    //    public CustomerDbContext():base("name=xandaposEntities") //Webconfig
    //    {
    //    }
    //    public virtual DbSet<CustomerMasterVM> CustomerData { get; set; }
    //}

    //public class CustomerDbContext : DbContext
    //{
    //    public DbSet<CustomerMasterVM> CustomerData { get; set; }
    //}

    //public class CustomerDbContext : DbContext
    //{
    //    public DbSet<POS_CUSTOMER_MASTER> CustomerData { get; set; }
    //}
}