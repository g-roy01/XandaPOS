using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using XandaPOS.Edmx;

namespace XandaPOS.Models
{
    public class DBContextMaster : DbContext
    {
        public DBContextMaster() : base("name=xandaposEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<POS_CUSTOMER_MASTER> CustomerData { get; set; }
    }
}

