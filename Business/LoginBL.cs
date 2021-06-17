using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Business
{
    public class LoginBL
    {
        public bool LoginVerifier(string id, string pass)
        {
            //Add verification logic here
            if (id.ToLower().Equals("admin") && pass.ToLower().Equals("admin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}