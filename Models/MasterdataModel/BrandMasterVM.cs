using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models.MasterdataModel
{
    public class BrandMasterData
    {
        public int brand_id { get; set; }
        public string brand_name { get; set; }
        public string brand_company_name { get; set; }
        public string brand_product_group_name { get; set; }
    }

    public class BrandMasterVM
    {
        public List<BrandMasterData> mainBrandData { get; set; }
        public List<CompanyMasterData> companyDetails { get; set; }
        public List<ProductGroupMasterVM> prodGrpDetails { get; set; }
    }

}