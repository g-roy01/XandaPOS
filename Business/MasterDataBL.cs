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

            using (var db = new xandaposEntities())
            {
                var posCustomerMaster = db.POS_CUSTOMER_MASTER;
                var list = posCustomerMaster.ToList();
                foreach (var item in list)
                {
                    CustomerMasterVM _customerMasterVM = new CustomerMasterVM();
                    _customerMasterVM.cust_id = item.cust_id;
                    _customerMasterVM.cust_addr = item.cust_addr.Trim();
                    _customerMasterVM.cust_name = item.cust_name.Trim();
                    _customerMasterVM.cust_pin = item.cust_pin.Trim();
                    _customerMasterVM.cust_phn = item.cust_phn.Trim();
                    _customerMasterVM.cust_email = item.cust_email.Trim();

                    lstCustomerMasterVM.Add(_customerMasterVM);
                }
                return lstCustomerMasterVM;
            } 
        }


        //Load Brand Grid
        public List<BrandMasterVM> LoadBrandMasterGrid()
        {
            List<BrandMasterVM> lstBrandMasterVM = new List<BrandMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posBrandMaster = db.POS_BRAND_MASTER;
                var posProdGrpMaster = db.POS_PRODUCT_GROUP_MASTER;

                var list = posBrandMaster.ToList();
                foreach (var item in list)
                {
                    BrandMasterVM _brandMasterVM = new BrandMasterVM();
                    _brandMasterVM.brand_id = item.brand_id.Trim();
                    _brandMasterVM.brand_name = item.brand_name.Trim();
                    _brandMasterVM.brand_company = item.brand_company.Trim();
                    _brandMasterVM.brand_product_group_id = item.brand_product_group.Trim();

                    var prodGroupName = posProdGrpMaster.Where(m => m.prod_grp_id.Equals(item.brand_product_group.Trim())).Select(m=>m.prod_grp_name);

                    _brandMasterVM.brand_product_group_name = prodGroupName.FirstOrDefault().ToString().Trim();

                    lstBrandMasterVM.Add(_brandMasterVM);
                }
                return lstBrandMasterVM;
            }
        }


        //Load Company Grid
        public List<CompanyMasterVM> LoadCompanyMasterGrid(string companyType)
        {
            //companyType - All, Vendor, Supplier

            List<CompanyMasterVM> lstCompanyMasterVM = new List<CompanyMasterVM>();
            
            using (var db = new xandaposEntities())
            {
                var posCompanyMaster = db.POS_COMPANY_MASTER;
                var posMasterTableHelperMaster = db.POS_MASTER_TABLE_HELPER;

                var list = posCompanyMaster.ToList();
                foreach (var item in list)
                {
                    CompanyMasterVM _companyMasterVM = new CompanyMasterVM();
                    _companyMasterVM.comp_id = item.comp_id.Trim();
                    _companyMasterVM.comp_name = item.comp_name.Trim();
                    _companyMasterVM.comp_regn_no = item.comp_regn_no.Trim();
                    _companyMasterVM.comp_type_id = item.comp_type.Trim();

                    var compName = posMasterTableHelperMaster
                                          .Where(m => m.helper_id.Equals(item.comp_type.Trim())).Select(s=>s)
                                          .Where(m=> m.helper_link_master_table.Equals("POS_COMPANY_MASTER")).Select(m => m.helper_name);

                    _companyMasterVM.comp_type_name = compName.FirstOrDefault().ToString().Trim();

                    lstCompanyMasterVM.Add(_companyMasterVM);
                }
                return lstCompanyMasterVM;
            }
        }


        //Load Employee Grid
        public List<EmployeeMasterVM> LoadEmployeeMasterGrid()
        {
            List<EmployeeMasterVM> lstEmployeeMasterVM = new List<EmployeeMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posEmployeeMaster = db.POS_EMPLOYEE_MASTER;
                var list = posEmployeeMaster.ToList();
                foreach (var item in list)
                {
                    EmployeeMasterVM _employeeMasterVM = new EmployeeMasterVM();
                    _employeeMasterVM.emp_id = item.emp_id.Trim();
                    _employeeMasterVM.emp_name = item.emp_name.Trim();
                    _employeeMasterVM.emp_addr = item.emp_addr.Trim();
                    _employeeMasterVM.emp_pin = item.emp_pin.Trim();
                    _employeeMasterVM.emp_phn = item.emp_phn.Trim();
                    _employeeMasterVM.emp_govt_id_type = item.emp_govt_id_type.Trim();
                    _employeeMasterVM.emp_govt_id_no = item.emp_govt_id_no.Trim();
                    _employeeMasterVM.emp_join_date = item.emp_join_date;
                    _employeeMasterVM.emp_resign_date = item.emp_resign_date;

                    lstEmployeeMasterVM.Add(_employeeMasterVM);
                }
                return lstEmployeeMasterVM;
            }
        }


        //Load Master Table Helper Grid
        public List<MasterTableHelperMasterVM> LoadMasterTableHelperMasterGrid()
        {
            List<MasterTableHelperMasterVM> lstMasterTableHelperMasterVM = new List<MasterTableHelperMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posMasterTableHelperMaster = db.POS_MASTER_TABLE_HELPER;
                var list = posMasterTableHelperMaster.ToList();
                foreach (var item in list)
                {
                    MasterTableHelperMasterVM _masterTableHelperMasterVM = new MasterTableHelperMasterVM();
                    _masterTableHelperMasterVM.helper_id = item.helper_id.Trim();
                    _masterTableHelperMasterVM.helper_name = item.helper_name.Trim();
                    _masterTableHelperMasterVM.helper_details = item.helper_details.Trim();
                    _masterTableHelperMasterVM.helper_link_master_table = item.helper_link_master_table.Trim();
                    _masterTableHelperMasterVM.helper_active = item.helper_active;

                    lstMasterTableHelperMasterVM.Add(_masterTableHelperMasterVM);
                }
                return lstMasterTableHelperMasterVM;
            }
        }


        //Load Product Group Grid
        public List<ProductGroupMasterVM> LoadProductGroupMasterGrid()
        {
            List<ProductGroupMasterVM> lstProductGroupMasterVM = new List<ProductGroupMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posProductGroupMaster = db.POS_PRODUCT_GROUP_MASTER;
                var list = posProductGroupMaster.ToList();
                foreach (var item in list)
                {
                    ProductGroupMasterVM _productGroupMasterVM = new ProductGroupMasterVM();
                    _productGroupMasterVM.prod_grp_id = item.prod_grp_id.Trim();
                    _productGroupMasterVM.prod_grp_name = item.prod_grp_name.Trim();
                    _productGroupMasterVM.prod_grp_type = item.prod_grp_type.Trim();

                    lstProductGroupMasterVM.Add(_productGroupMasterVM);
                }
                return lstProductGroupMasterVM;
            }
        }


        //Load Product Grid
        public List<ProductMasterVM> LoadProductMasterGrid()
        {
            List<ProductMasterVM> lstProductMasterVM = new List<ProductMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posProductMaster = db.POS_PRODUCT_MASTER;
                var posMasterTableHelperMaster = db.POS_MASTER_TABLE_HELPER;
                var posProductGroupMaster = db.POS_PRODUCT_GROUP_MASTER;
                var posCompanyMaster = db.POS_COMPANY_MASTER;

                var list = posProductMaster.ToList();
                foreach (var item in list)
                {
                    ProductMasterVM _productMasterVM = new ProductMasterVM();
                    _productMasterVM.product_id = item.product_id.Trim();
                    _productMasterVM.product_name = item.product_name.Trim();

                    _productMasterVM.product_type_id = item.product_type.Trim();
                    var prodTypeName = posMasterTableHelperMaster
                                        .Where(m => m.helper_id.Equals(item.product_type.Trim())).Select(s => s)
                                        .Where(m => m.helper_link_master_table.Equals("POS_PRODUCT_MASTER")).Select(m => m.helper_name);
                    _productMasterVM.product_type_name = prodTypeName.FirstOrDefault().ToString().Trim();

                    _productMasterVM.product_group_id = item.product_group.Trim();
                    var prodGroupName = posProductGroupMaster.Where(m => m.prod_grp_id.Equals(item.product_group.Trim())).Select(m => m.prod_grp_name);
                    _productMasterVM.product_group_name = prodGroupName.FirstOrDefault().ToString().Trim();

                    _productMasterVM.product_company_id = item.product_company.Trim();
                    var prodCompName = posCompanyMaster.Where(m => m.comp_id.Equals(item.product_company.Trim())).Select(m => m.comp_name);
                    _productMasterVM.product_company_name = prodCompName.FirstOrDefault().ToString().Trim();

                    _productMasterVM.product_details = item.product_details.Trim();
                    if(string.IsNullOrEmpty(item.product_image_link))
                        _productMasterVM.product_image_link = "NO IMAGE LINKED";
                    else
                        _productMasterVM.product_image_link = item.product_image_link.Trim();

                    lstProductMasterVM.Add(_productMasterVM);
                }
                return lstProductMasterVM;
            }
        }


        //Load Warehouse Grid
        public List<WarehouseMasterVM> LoadWarehouseMasterGrid()
        {
            List<WarehouseMasterVM> lstWarehouseMasterVM = new List<WarehouseMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posWarehouseMaster = db.POS_WAREHOUSE_MASTER;
                var list = posWarehouseMaster.ToList();
                foreach (var item in list)
                {
                    WarehouseMasterVM _warehouseMasterVM = new WarehouseMasterVM();
                    _warehouseMasterVM.warehouse_id = item.warehouse_id;
                    _warehouseMasterVM.warehouse_name = item.warehouse_name;
                    _warehouseMasterVM.warehouse_address = item.warehouse_address;
                    _warehouseMasterVM.warehouse_pin = item.warehouse_pin;
                    _warehouseMasterVM.warehouse_phone = item.warehouse_phone;
                    _warehouseMasterVM.warehouse_code = item.warehouse_code;

                    lstWarehouseMasterVM.Add(_warehouseMasterVM);
                }
                return lstWarehouseMasterVM;
            }
        }


    }
}