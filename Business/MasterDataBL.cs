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
                    _customerMasterVM.cust_addr = item.cust_addr;
                    _customerMasterVM.cust_name = item.cust_name;
                    _customerMasterVM.cust_pin = item.cust_pin;
                    _customerMasterVM.cust_phn = item.cust_phn;

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
                var list = posBrandMaster.ToList();
                foreach (var item in list)
                {
                    BrandMasterVM _brandMasterVM = new BrandMasterVM();
                    _brandMasterVM.brand_id = item.brand_id;
                    _brandMasterVM.brand_name = item.brand_name;
                    _brandMasterVM.brand_company = item.brand_company;
                    _brandMasterVM.brand_product_group = item.brand_product_group;

                    lstBrandMasterVM.Add(_brandMasterVM);
                }
                return lstBrandMasterVM;
            }
        }


        //Load Company Grid
        public List<CompanyMasterVM> LoadCompanyMasterGrid()
        {
            List<CompanyMasterVM> lstCompanyMasterVM = new List<CompanyMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posCompanyMaster = db.POS_COMPANY_MASTER;
                var list = posCompanyMaster.ToList();
                foreach (var item in list)
                {
                    CompanyMasterVM _companyMasterVM = new CompanyMasterVM();
                    _companyMasterVM.comp_id = item.comp_id;
                    _companyMasterVM.comp_name = item.comp_name;
                    _companyMasterVM.comp_regn_no = item.comp_regn_no;
                    _companyMasterVM.comp_type = item.comp_type;

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
                    _employeeMasterVM.emp_id = item.emp_id;
                    _employeeMasterVM.emp_name = item.emp_name;
                    _employeeMasterVM.emp_addr = item.emp_addr;
                    _employeeMasterVM.emp_pin = item.emp_pin;
                    _employeeMasterVM.emp_phn = item.emp_phn;
                    _employeeMasterVM.emp_govt_id_type = item.emp_govt_id_type;
                    _employeeMasterVM.emp_govt_id_no = item.emp_govt_id_no;
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
                    _masterTableHelperMasterVM.helper_id = item.helper_id;
                    _masterTableHelperMasterVM.helper_name = item.helper_name;
                    _masterTableHelperMasterVM.helper_details = item.helper_details;
                    _masterTableHelperMasterVM.helper_link_master_table = item.helper_link_master_table;
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
                    _productGroupMasterVM.prod_grp_id = item.prod_grp_id;
                    _productGroupMasterVM.prod_grp_name = item.prod_grp_name;
                    _productGroupMasterVM.prod_grp_type = item.prod_grp_type;

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
                var list = posProductMaster.ToList();
                foreach (var item in list)
                {
                    ProductMasterVM _productMasterVM = new ProductMasterVM();
                    _productMasterVM.product_id = item.product_id;
                    _productMasterVM.product_name = item.product_name;
                    _productMasterVM.product_type = item.product_type;
                    _productMasterVM.product_group = item.product_group;
                    _productMasterVM.product_company = item.product_company;
                    _productMasterVM.product_details = item.product_details;
                    _productMasterVM.product_image_link = item.product_image_link;

                    lstProductMasterVM.Add(_productMasterVM);
                }
                return lstProductMasterVM;
            }
        }


    }
}