using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XandaPOS.Edmx;

namespace XandaPOS.BusinessData
{
    public class BusinessData
    {
        public int AddCustomerToDB(string custName, string custAddress, string custPinCode, string custPhnData, string custEmailData)
        {
            using (var db = new xandaposEntities())
            {
                int data = db.sp_AddNewCustomer(custName, custAddress, custPinCode, custPhnData, custEmailData);
                var a = 0;
            }
            return 0;
        }   
    }
}