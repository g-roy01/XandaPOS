using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XandaPOS.Edmx;
using XandaPOS.Models;

namespace XandaPOS.Business
{
    public class MasterDataBL
    {
        // Load Customer Grid
        public List<CustomerMasterVM> LoadCustomerMasterGrid()
        {
            List<CustomerMasterVM> lstCustomerMasterVM = new List<CustomerMasterVM>();

            using (var db = new xandaposEntities1())
            {
                var ctx = db.POS_CUSTOMER_MASTER;
                var list =  ctx.ToList();
                foreach (var item in list)
                {
                    CustomerMasterVM _CustomerMasterVM = new CustomerMasterVM();
                    _CustomerMasterVM.cust_addr = item.cust_addr;
                    _CustomerMasterVM.cust_name = item.cust_name;
                    lstCustomerMasterVM.Add(_CustomerMasterVM);
                }
                return lstCustomerMasterVM;
            } 
        }


    }
}