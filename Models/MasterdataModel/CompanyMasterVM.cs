using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models.MasterdataModel
{
    public class CompanyMasterData
    {
        public int comp_id { get; set; }
        public string comp_name { get; set; }
        public string comp_address { get; set; }
        public string comp_pin { get; set; }
        public string comp_type_name { get; set; }
        public string comp_regn_no { get; set; }
    }

    public class CompanyMasterVM
    {
        public List<CompanyMasterData> mainCompanyData { get; set; }
        public List<MasterTableHelperMasterVM> companyHelper { get; set; }
    }

}