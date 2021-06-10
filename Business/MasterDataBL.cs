﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XandaPOS.Edmx;
using XandaPOS.Models;

namespace XandaPOS.Business
{
    public class MasterDataBL
    {
        #region CUSTOMER MASTER

        // Load Customer Grid
        public List<CustomerMasterVM> LoadCustomerMasterGrid(int custID)
        {
            List<CustomerMasterVM> lstCustomerMasterVM = new List<CustomerMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posCustomerMaster = db.POS_CUSTOMER_MASTER;

                var list = posCustomerMaster.ToList();

                if (custID > 0) //If we want a single data
                {
                    list.Clear();
                    var custData = posCustomerMaster.Where(x => x.cust_id == custID).FirstOrDefault();
                    list.Add(custData);
                }
                
                foreach (var item in list)
                {
                    CustomerMasterVM _customerMasterVM = new CustomerMasterVM();
                    _customerMasterVM.cust_id = item.cust_id;
                    _customerMasterVM.cust_addr = string.IsNullOrEmpty(item.cust_addr) ? "" : item.cust_addr.Trim();
                    _customerMasterVM.cust_name = string.IsNullOrEmpty(item.cust_name) ? "" : item.cust_name.Trim();
                    _customerMasterVM.cust_pin = string.IsNullOrEmpty(item.cust_pin) ? "" : item.cust_pin.Trim();
                    _customerMasterVM.cust_phn = string.IsNullOrEmpty(item.cust_phn)? "": item.cust_phn.Trim();
                    _customerMasterVM.cust_email = string.IsNullOrEmpty(item.cust_email) ? "" : item.cust_email.Trim();

                    lstCustomerMasterVM.Add(_customerMasterVM);
                }
                return lstCustomerMasterVM;
            } 
        }

        //Add Customer Master
        public string AddCustomerMaster(POS_CUSTOMER_MASTER custData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_CUSTOMER_MASTER.Add(custData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Update Customer Master
        public string UpdateCustomerMaster(POS_CUSTOMER_MASTER custData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_CUSTOMER_MASTER.Where(x => x.cust_id == custData.cust_id).FirstOrDefault();
                    retVal.cust_name = custData.cust_name;
                    retVal.cust_addr = custData.cust_addr;
                    retVal.cust_pin = custData.cust_pin;
                    retVal.cust_phn = custData.cust_phn;
                    retVal.cust_email = custData.cust_email;
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Customer Master
        public string DeleteCustomerMaster(int custId)
        {
            string message = "";
            try
            {
                using(var db = new xandaposEntities())
                {
                    var retVal = db.POS_CUSTOMER_MASTER.Where(x => x.cust_id == custId).FirstOrDefault();
                    db.POS_CUSTOMER_MASTER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch(Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        #endregion

        #region BRAND MASTER
        
        //Load Brand Grid
        public List<BrandMasterVM> LoadBrandMasterGrid(int v)
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
                    _brandMasterVM.brand_id = item.brand_id;
                    _brandMasterVM.brand_name = item.brand_name.Trim();
                    _brandMasterVM.brand_company = item.brand_company;
                    _brandMasterVM.brand_product_group_id = item.brand_product_group;

                    var prodGroupName = posProdGrpMaster.Where(m => m.prod_grp_id.Equals(item.brand_product_group)).Select(m=>m.prod_grp_name);

                    _brandMasterVM.brand_product_group_name = prodGroupName.FirstOrDefault().ToString().Trim();

                    lstBrandMasterVM.Add(_brandMasterVM);
                }
                return lstBrandMasterVM;
            }
        }

        //Add Brand Master
        public string AddBrandMaster(POS_BRAND_MASTER brandData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_BRAND_MASTER.Add(brandData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        
        //Update Brand Master
        public string UpdateBrandMaster(POS_BRAND_MASTER brandData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_BRAND_MASTER.Where(x => x.brand_id == brandData.brand_id).FirstOrDefault();
                    retVal.brand_id = brandData.brand_id;
                    retVal.brand_name = brandData.brand_name;
                    retVal.brand_company = brandData.brand_company;
                    retVal.brand_product_group = brandData.brand_product_group;

                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Brand Master
        public string DeleteBrandMaster(int brandId)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_BRAND_MASTER.Where(x => x.brand_id == brandId).FirstOrDefault();
                    db.POS_BRAND_MASTER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        #endregion

        #region COMPANY MASTER
        //Load Company Grid
        public List<CompanyMasterVM> LoadCompanyMasterGrid(string companyType)
        {
            //companyType - ALL, VENDOR, SUPPLIER

            List<CompanyMasterVM> lstCompanyMasterVM = new List<CompanyMasterVM>();
            
            using (var db = new xandaposEntities())
            {
                var posCompanyMaster = db.POS_COMPANY_MASTER;
                var posMasterTableHelperMaster = db.POS_MASTER_TABLE_HELPER;

                //For CompanyType = ALL
                var list = posCompanyMaster.ToList();

                if (companyType.Equals("VENDOR"))
                {
                    var vendorTypeCode = posMasterTableHelperMaster
                                          .Where(m => m.helper_name.Trim().Equals("VENDOR")).Select(s => s)
                                          .Where(m => m.helper_link_master_table.Equals("POS_COMPANY_MASTER")).Select(m => m.helper_id);

                    list.Clear();
                    list = posCompanyMaster
                                .Where(m => m.comp_type.Equals(vendorTypeCode.FirstOrDefault())).Select(s => s).ToList();
                }

                if (companyType.Equals("SUPPLIER"))
                {
                    var supplierTypeCode = posMasterTableHelperMaster
                                            .Where(m => m.helper_name.Trim().Equals("SUPPLIER")).Select(s => s)
                                            .Where(m => m.helper_link_master_table.Equals("POS_COMPANY_MASTER")).Select(m => m.helper_id);

                    list.Clear();
                    list = posCompanyMaster
                                .Where(m => m.comp_type.Equals(supplierTypeCode.FirstOrDefault())).Select(s => s).ToList();
                }
                
                foreach (var item in list)
                {
                    CompanyMasterVM _companyMasterVM = new CompanyMasterVM();
                    _companyMasterVM.comp_id = item.comp_id;
                    _companyMasterVM.comp_name = item.comp_name.Trim();
                    _companyMasterVM.comp_regn_no = item.comp_regn_no.Trim();
                    _companyMasterVM.comp_type_id = item.comp_type;

                    var compName = posMasterTableHelperMaster
                                          .Where(m => m.helper_id.Equals(item.comp_type)).Select(s => s)
                                          .Where(m => m.helper_link_master_table.Equals("POS_COMPANY_MASTER")).Select(m => m.helper_name);

                    _companyMasterVM.comp_type_name = compName.FirstOrDefault().ToString().Trim();

                    lstCompanyMasterVM.Add(_companyMasterVM);
                }

                return lstCompanyMasterVM;
            }
        }

        //Add Company Master
        public string AddCompanyMaster(POS_COMPANY_MASTER companyData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_COMPANY_MASTER.Add(companyData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Update Company Master
        public string UpdateCompanyMaster(POS_COMPANY_MASTER companyData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_COMPANY_MASTER.Where(x => x.comp_id == companyData.comp_id).FirstOrDefault();

                    retVal.comp_id = companyData.comp_id;
                    retVal.comp_name = companyData.comp_name;
                    retVal.comp_address = companyData.comp_address;
                    retVal.comp_pin = companyData.comp_pin;
                    retVal.comp_regn_no = companyData.comp_regn_no;
                    retVal.comp_type = companyData.comp_type;


                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Company Master
        public string DeleteCompanyMaster(int compId)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_COMPANY_MASTER.Where(x => x.comp_id == compId).FirstOrDefault();
                    db.POS_COMPANY_MASTER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        #endregion

        #region EMPLOYEE MASTER
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
                    _employeeMasterVM.emp_name = item.emp_name.Trim();
                    _employeeMasterVM.emp_addr = item.emp_addr.Trim();
                    _employeeMasterVM.emp_pin = item.emp_pin.Trim();
                    _employeeMasterVM.emp_phone = item.emp_phone.Trim();
                    _employeeMasterVM.emp_govt_id_type = item.emp_govt_id_type.Trim();
                    _employeeMasterVM.emp_govt_id_no = item.emp_govt_id_no.Trim();
                    _employeeMasterVM.emp_join_date = item.emp_join_date;
                    _employeeMasterVM.emp_resign_date = item.emp_resign_date;

                    lstEmployeeMasterVM.Add(_employeeMasterVM);
                }
                return lstEmployeeMasterVM;
            }
        }

        //Add Employee Master
        public string AddEmployeeMaster(POS_EMPLOYEE_MASTER employeeData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_EMPLOYEE_MASTER.Add(employeeData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Update Employee Master
        public string UpdateEmployeeMaster(POS_EMPLOYEE_MASTER employeeData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_EMPLOYEE_MASTER.Where(x => x.emp_id == employeeData.emp_id).FirstOrDefault();

                    retVal.emp_id = employeeData.emp_id;
                    retVal.emp_name = employeeData.emp_name.Trim();
                    retVal.emp_addr = employeeData.emp_addr.Trim();
                    retVal.emp_pin = employeeData.emp_pin.Trim();
                    retVal.emp_phone = employeeData.emp_phone.Trim();
                    retVal.emp_govt_id_type = employeeData.emp_govt_id_type.Trim();
                    retVal.emp_govt_id_no = employeeData.emp_govt_id_no.Trim();
                    retVal.emp_join_date = employeeData.emp_join_date;
                    retVal.emp_resign_date = employeeData.emp_resign_date;

                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Company Master
        public string DeleteEmployeeMaster(int empId)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_EMPLOYEE_MASTER.Where(x => x.emp_id == empId).FirstOrDefault();
                    db.POS_EMPLOYEE_MASTER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        #endregion

        #region MASTER TABLE HELPER
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
                    _masterTableHelperMasterVM.helper_name = item.helper_name.Trim();
                    _masterTableHelperMasterVM.helper_details = item.helper_details.Trim();
                    _masterTableHelperMasterVM.helper_link_master_table = item.helper_link_master_table.Trim();
                    _masterTableHelperMasterVM.helper_active = item.helper_active;

                    lstMasterTableHelperMasterVM.Add(_masterTableHelperMasterVM);
                }
                return lstMasterTableHelperMasterVM;
            }
        }

        //Add Master Table Helper Master
        public string AddMasterTableHelperMaster(POS_MASTER_TABLE_HELPER helperData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_MASTER_TABLE_HELPER.Add(helperData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Update Master Table Helper Master
        public string UpdateMasterTableHelperMaster(POS_MASTER_TABLE_HELPER helperData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_MASTER_TABLE_HELPER.Where(x => x.helper_id == helperData.helper_id).FirstOrDefault();

                    retVal.helper_id = helperData.helper_id;
                    retVal.helper_name = helperData.helper_name.Trim();
                    retVal.helper_details = helperData.helper_details.Trim();
                    retVal.helper_link_master_table = helperData.helper_link_master_table.Trim();
                    retVal.helper_active = helperData.helper_active;

                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Master Table Helper Master
        public string DeleteMasterTableHelperMaster(int helperId)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_MASTER_TABLE_HELPER.Where(x => x.helper_id == helperId).FirstOrDefault();
                    db.POS_MASTER_TABLE_HELPER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        #endregion

        #region PRODUCT GROUP MASTER

        //Load Product Group Grid
        public List<ProductGroupMasterVM> LoadProductGroupMasterGrid(int prodGrpId)
        {
            List<ProductGroupMasterVM> lstProductGroupMasterVM = new List<ProductGroupMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posProductGroupMaster = db.POS_PRODUCT_GROUP_MASTER;
                var list = posProductGroupMaster.ToList();

                if (prodGrpId > 0) //If we want a single data
                {
                    list.Clear();
                    var prodGrpData = posProductGroupMaster.Where(x => x.prod_grp_id == prodGrpId).FirstOrDefault();
                    list.Add(prodGrpData);
                }

                foreach (var item in list)
                {
                    ProductGroupMasterVM _productGroupMasterVM = new ProductGroupMasterVM();
                    _productGroupMasterVM.prod_grp_id = item.prod_grp_id;
                    _productGroupMasterVM.prod_grp_name = item.prod_grp_name.Trim();
                    _productGroupMasterVM.prod_grp_type = item.prod_grp_type.Trim();

                    lstProductGroupMasterVM.Add(_productGroupMasterVM);
                }
                return lstProductGroupMasterVM;
            }
        }

        //Add Product Group Master
        public string AddProductGroupMaster(POS_PRODUCT_GROUP_MASTER prodGrpData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_PRODUCT_GROUP_MASTER.Add(prodGrpData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Update Product Group Master
        public string UpdateProductGroupMaster(POS_PRODUCT_GROUP_MASTER prodGrpData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_PRODUCT_GROUP_MASTER.Where(x => x.prod_grp_id == prodGrpData.prod_grp_id).FirstOrDefault();

                    retVal.prod_grp_id = prodGrpData.prod_grp_id;
                    retVal.prod_grp_name = prodGrpData.prod_grp_name.Trim();
                    retVal.prod_grp_type = prodGrpData.prod_grp_type.Trim();

                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Product Group Master
        public string DeleteProductGroupMaster(int prodGrpId)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_PRODUCT_GROUP_MASTER.Where(x => x.prod_grp_id == prodGrpId).FirstOrDefault();
                    db.POS_PRODUCT_GROUP_MASTER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        #endregion

        #region PRODUCT MASTER
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
                    _productMasterVM.product_id = item.product_id;
                    _productMasterVM.product_name = item.product_name.Trim();

                    _productMasterVM.product_type_id = item.product_type;
                    var prodTypeName = posMasterTableHelperMaster
                                        .Where(m => m.helper_id.Equals(item.product_type)).Select(s => s)
                                        .Where(m => m.helper_link_master_table.Equals("POS_PRODUCT_MASTER")).Select(m => m.helper_name);
                    _productMasterVM.product_type_name = prodTypeName.FirstOrDefault().ToString().Trim();

                    _productMasterVM.product_group_id = item.product_group;
                    var prodGroupName = posProductGroupMaster.Where(m => m.prod_grp_id.Equals(item.product_group)).Select(m => m.prod_grp_name);
                    _productMasterVM.product_group_name = prodGroupName.FirstOrDefault().ToString().Trim();

                    _productMasterVM.product_company_id = item.product_company;
                    var prodCompName = posCompanyMaster.Where(m => m.comp_id.Equals(item.product_company)).Select(m => m.comp_name);
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

        //Add Product Master
        public string AddProductMaster(POS_PRODUCT_MASTER prodData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_PRODUCT_MASTER.Add(prodData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Update Product Master
        public string UpdateProductMaster(POS_PRODUCT_MASTER prodData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_PRODUCT_MASTER.Where(x => x.product_id == prodData.product_id).FirstOrDefault();

                    retVal.product_id = prodData.product_id;
                    retVal.product_name = prodData.product_name.Trim();

                    retVal.product_type = prodData.product_type;

                    retVal.product_group = prodData.product_group;
                    
                    retVal.product_company = prodData.product_company;

                    retVal.product_details = prodData.product_details.Trim();
                    if (string.IsNullOrEmpty(prodData.product_image_link))
                        retVal.product_image_link = "NO IMAGE LINKED";
                    else
                        retVal.product_image_link = prodData.product_image_link.Trim();

                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Product Master
        public string DeleteProductMaster(int prodId)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_PRODUCT_MASTER.Where(x => x.product_id == prodId).FirstOrDefault();
                    db.POS_PRODUCT_MASTER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }
        #endregion

        #region WAREHOUSE MASTER
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

        //Add Warehouse Master
        public string AddWarehouseMaster(POS_WAREHOUSE_MASTER warehouseData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    db.POS_WAREHOUSE_MASTER.Add(warehouseData);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Update Warehouse Master
        public string UpdateWarehouseMaster(POS_WAREHOUSE_MASTER warehouseData)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_WAREHOUSE_MASTER.Where(x => x.warehouse_id == warehouseData.warehouse_id).FirstOrDefault();

                    retVal.warehouse_id = warehouseData.warehouse_id;
                    retVal.warehouse_name = warehouseData.warehouse_name;
                    retVal.warehouse_address = warehouseData.warehouse_address;
                    retVal.warehouse_pin = warehouseData.warehouse_pin;
                    retVal.warehouse_phone = warehouseData.warehouse_phone;
                    retVal.warehouse_code = warehouseData.warehouse_code;


                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        //Delete Warehouse Master
        public string DeleteWarehouseMaster(int warehouseId)
        {
            string message = "";
            try
            {
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_WAREHOUSE_MASTER.Where(x => x.warehouse_id == warehouseId).FirstOrDefault();
                    db.POS_WAREHOUSE_MASTER.Remove(retVal);
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return message;
        }

        #endregion

    }
}