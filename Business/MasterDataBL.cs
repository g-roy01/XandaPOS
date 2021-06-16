using System;
using System.Collections.Generic;
using System.Linq;
using XandaPOS.Edmx;
using XandaPOS.Models.MasterdataModel;

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
                    _customerMasterVM.cust_addr = StrCleanDataOrEmpty(item.cust_addr);
                    _customerMasterVM.cust_name = StrCleanDataOrEmpty(item.cust_name);
                    _customerMasterVM.cust_pin = StrCleanDataOrEmpty(item.cust_pin);
                    _customerMasterVM.cust_phn = StrCleanDataOrEmpty(item.cust_phn);
                    _customerMasterVM.cust_email = StrCleanDataOrEmpty(item.cust_email);

                    lstCustomerMasterVM.Add(_customerMasterVM);
                }
                return lstCustomerMasterVM.OrderBy(a => a.cust_name).ToList();
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
                    retVal.cust_name = StrCleanDataOrEmpty(custData.cust_name);
                    retVal.cust_addr = StrCleanDataOrEmpty(custData.cust_addr);
                    retVal.cust_pin = StrCleanDataOrEmpty(custData.cust_pin);
                    retVal.cust_phn = StrCleanDataOrEmpty(custData.cust_phn);
                    retVal.cust_email = StrCleanDataOrEmpty(custData.cust_email);
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
                using (var db = new xandaposEntities())
                {
                    var retVal = db.POS_CUSTOMER_MASTER.Where(x => x.cust_id == custId).FirstOrDefault();
                    db.POS_CUSTOMER_MASTER.Remove(retVal);
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

        #region BRAND MASTER

        //Load Brand Grid
        public BrandMasterVM LoadBrandMasterGrid(int brandID = 0, string operation = "GET")
        {
            List<BrandMasterData> lstBrandMaster = new List<BrandMasterData>();

            using (var db = new xandaposEntities())
            {
                var posBrandMaster = db.POS_BRAND_MASTER;
                var list = posBrandMaster.ToList();

                if (brandID > 0)
                {
                    list.Clear();
                    var brandDetails = posBrandMaster.Where(x => x.brand_id == brandID).FirstOrDefault();
                    list.Add(brandDetails);
                }

                foreach (var item in list)
                {
                    BrandMasterData _brandMaster = new BrandMasterData();
                    _brandMaster.brand_id = item.brand_id;
                    _brandMaster.brand_name = StrCleanDataOrEmpty(item.brand_name);

                    var companyName = "";
                    try
                    {
                        if (operation.Equals("GET"))
                        {
                            companyName = FetchCompanyList().mainCompanyData
                                        .Where(x => x.comp_id == item.brand_company)
                                        .FirstOrDefault().comp_name;
                        }
                        if (operation.Equals("EDIT"))
                        {
                            if (item.brand_company == 0)//Here this condition represents no proper value
                                companyName = "NA";
                            else
                                companyName = item.brand_company.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (operation.Equals("GET"))
                        {
                            companyName = "";
                        }
                        if (operation.Equals("EDIT"))
                        {
                            companyName = "NA";
                        }
                    }
                    _brandMaster.brand_company_name = StrCleanDataOrEmpty(companyName);

                    var prodGroupName = "";
                    try
                    {
                        if (operation.Equals("GET"))
                        {
                            if (item.brand_product_group == null)
                                prodGroupName = "";
                            else
                                prodGroupName = LoadProductGroupMasterGrid(item.brand_product_group.GetValueOrDefault())[0].prod_grp_name;
                        }
                        if (operation.Equals("EDIT"))
                        {

                            if (item.brand_product_group == null)
                                prodGroupName = "NA";
                            else
                                prodGroupName = item.brand_product_group.GetValueOrDefault().ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (operation.Equals("GET"))
                        {
                            prodGroupName = "";
                        }
                        if (operation.Equals("GET"))
                        {
                            prodGroupName = "NA";
                        }
                    }
                    _brandMaster.brand_product_group_name = StrCleanDataOrEmpty(prodGroupName);

                    lstBrandMaster.Add(_brandMaster);
                }

                BrandMasterVM _brandMasterVM = new BrandMasterVM();
                _brandMasterVM.mainBrandData = lstBrandMaster.OrderBy(a => a.brand_name).ToList();
                _brandMasterVM.companyDetails = FetchCompanyList().mainCompanyData;
                _brandMasterVM.prodGrpDetails = LoadProductGroupMasterGrid(0);

                return _brandMasterVM;
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
        public CompanyMasterVM LoadCompanyMasterGrid(int companyID, string companyType = "ALL", string operation = "GET")
        {
            //companyType - ALL, VENDOR, SUPPLIER

            List<CompanyMasterData> lstCompanyMasterVM = new List<CompanyMasterData>();

            using (var db = new xandaposEntities())
            {
                var posCompanyMaster = db.POS_COMPANY_MASTER;
                //var posMasterTableHelperMaster = db.POS_MASTER_TABLE_HELPER;

                //For CompanyType = ALL
                var list = posCompanyMaster.ToList();

                if (operation.Equals("EDIT") && companyID > 0)
                {
                    list.Clear();
                    var companyList = posCompanyMaster.Where(x => x.comp_id == companyID).FirstOrDefault();
                    list.Add(companyList);
                }

                //if (companyType.Equals("VENDOR"))
                //{
                //    var vendorTypeCode = posMasterTableHelperMaster
                //                          .Where(m => m.helper_name.Trim().Equals("VENDOR")).Select(s => s)
                //                          .Where(m => m.helper_link_master_table.Equals("POS_COMPANY_MASTER")).Select(m => m.helper_id);

                //    list.Clear();
                //    list = posCompanyMaster
                //                .Where(m => m.comp_type.Equals(vendorTypeCode.FirstOrDefault())).Select(s => s).ToList();
                //}

                //if (companyType.Equals("SUPPLIER"))
                //{
                //    var supplierTypeCode = posMasterTableHelperMaster
                //                            .Where(m => m.helper_name.Trim().Equals("SUPPLIER")).Select(s => s)
                //                            .Where(m => m.helper_link_master_table.Equals("POS_COMPANY_MASTER")).Select(m => m.helper_id);

                //    list.Clear();
                //    list = posCompanyMaster
                //                .Where(m => m.comp_type.Equals(supplierTypeCode.FirstOrDefault())).Select(s => s).ToList();
                //}

                foreach (var item in list)
                {
                    CompanyMasterData _companyMaster = new CompanyMasterData();
                    _companyMaster.comp_id = item.comp_id;
                    _companyMaster.comp_name = StrCleanDataOrEmpty(item.comp_name);
                    _companyMaster.comp_address = StrCleanDataOrEmpty(item.comp_address);
                    _companyMaster.comp_pin = StrCleanDataOrEmpty(item.comp_pin);
                    _companyMaster.comp_regn_no = StrCleanDataOrEmpty(item.comp_regn_no);

                    string helperName = "";
                    try
                    {
                        if (operation.Equals("GET"))
                        {
                            helperName = FetchMasterTableHelperList("POS_COMPANY_MASTER")
                                                                  .Where(x => x.helper_id == item.comp_type).FirstOrDefault().helper_name;
                        }
                        if (operation.Equals("EDIT"))
                        {
                            helperName = item.comp_type.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        helperName = "";
                    }
                    _companyMaster.comp_type_name = StrCleanDataOrEmpty(helperName);

                    lstCompanyMasterVM.Add(_companyMaster);
                }

                CompanyMasterVM _compMasterVM = new CompanyMasterVM();
                _compMasterVM.mainCompanyData = lstCompanyMasterVM.OrderBy(a => a.comp_name).ToList();
                _compMasterVM.companyHelper = FetchMasterTableHelperList("POS_COMPANY_MASTER");

                return _compMasterVM;
            }
        }

        //Fetch Company Details for Destination Tables
        public CompanyMasterVM FetchCompanyList()
        {
            //companyType - ALL, VENDOR, SUPPLIER

            List<CompanyMasterData> lstCompanyMasterVM = new List<CompanyMasterData>();

            using (var db = new xandaposEntities())
            {
                var posCompanyMaster = db.POS_COMPANY_MASTER;

                //For CompanyType = ALL
                var list = posCompanyMaster.ToList();

                foreach (var item in list)
                {
                    CompanyMasterData _companyMaster = new CompanyMasterData();
                    _companyMaster.comp_id = item.comp_id;
                    _companyMaster.comp_name = StrCleanDataOrEmpty(item.comp_name);
                    _companyMaster.comp_address = StrCleanDataOrEmpty(item.comp_address);
                    _companyMaster.comp_pin = StrCleanDataOrEmpty(item.comp_pin);
                    _companyMaster.comp_regn_no = StrCleanDataOrEmpty(item.comp_regn_no);

                    string helperName = "";
                    try
                    {
                        helperName = FetchMasterTableHelperList("POS_COMPANY_MASTER")
                                                                  .Where(x => x.helper_id == item.comp_type).FirstOrDefault().helper_name;
                    }
                    catch (Exception ex)
                    {
                        helperName = "";
                    }
                    _companyMaster.comp_type_name = StrCleanDataOrEmpty(helperName);

                    lstCompanyMasterVM.Add(_companyMaster);
                }

                CompanyMasterVM _compMasterVM = new CompanyMasterVM();
                _compMasterVM.mainCompanyData = lstCompanyMasterVM.OrderBy(a => a.comp_name).ToList();
                _compMasterVM.companyHelper = FetchMasterTableHelperList("POS_COMPANY_MASTER");

                return _compMasterVM;
            }
        }

        //Fetch Company Type Details for Destination Tables
        public List<CompanyMasterData> FetchCompanyTypeList(string companyType)
        {
            //companyType could be - "SUPPLIER","VENDOR"
            List<CompanyMasterData> _companyTypeDetailsList = new List<CompanyMasterData>();
            List<MasterTableHelperMasterVM> _companyHelperMaster = FetchMasterTableHelperList("POS_COMPANY_MASTER");

            var companyTypeId = 0;
            try
            {
                companyTypeId = _companyHelperMaster.Where(x => x.helper_name.ToUpper().Equals(companyType)).Select(s => s.helper_id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                companyTypeId = 0;
            }

            using (var db = new xandaposEntities())
            {
                var compMasterList = db.POS_COMPANY_MASTER.Where(x => x.comp_type == companyTypeId).ToList();

                foreach (var item in compMasterList)
                {
                    CompanyMasterData _companyMaster = new CompanyMasterData();
                    _companyMaster.comp_id = item.comp_id;
                    _companyMaster.comp_name = StrCleanDataOrEmpty(item.comp_name);
                    _companyMaster.comp_address = StrCleanDataOrEmpty(item.comp_address);
                    _companyMaster.comp_pin = StrCleanDataOrEmpty(item.comp_pin);
                    _companyMaster.comp_regn_no = StrCleanDataOrEmpty(item.comp_regn_no);

                    string helperName = "";
                    try
                    {
                        helperName = _companyHelperMaster.Where(x => x.helper_id == item.comp_type).FirstOrDefault().helper_name;
                    }
                    catch (Exception ex)
                    {
                        helperName = "";
                    }
                    _companyMaster.comp_type_name = StrCleanDataOrEmpty(helperName);
                    _companyTypeDetailsList.Add(_companyMaster);
                }
            }

            return _companyTypeDetailsList.OrderBy(a => a.comp_name).ToList();
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
                    retVal.comp_name = StrCleanDataOrEmpty(companyData.comp_name);
                    retVal.comp_address = StrCleanDataOrEmpty(companyData.comp_address);
                    retVal.comp_pin = StrCleanDataOrEmpty(companyData.comp_pin);
                    retVal.comp_regn_no = StrCleanDataOrEmpty(companyData.comp_regn_no);
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
        public List<EmployeeMasterVM> LoadEmployeeMasterGrid(int empId)
        {
            List<EmployeeMasterVM> lstEmployeeMasterVM = new List<EmployeeMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posEmployeeMaster = db.POS_EMPLOYEE_MASTER;
                var list = posEmployeeMaster.ToList();

                if (empId > 0)
                {
                    list.Clear();
                    var empList = posEmployeeMaster.Where(x => x.emp_id == empId).FirstOrDefault();
                    list.Add(empList);
                }

                foreach (var item in list)
                {
                    EmployeeMasterVM _employeeMasterVM = new EmployeeMasterVM();
                    _employeeMasterVM.emp_id = item.emp_id;
                    _employeeMasterVM.emp_name = StrCleanDataOrEmpty(item.emp_name);
                    _employeeMasterVM.emp_addr = StrCleanDataOrEmpty(item.emp_addr);
                    _employeeMasterVM.emp_pin = StrCleanDataOrEmpty(item.emp_pin);
                    _employeeMasterVM.emp_phone = StrCleanDataOrEmpty(item.emp_phone);
                    _employeeMasterVM.emp_email = StrCleanDataOrEmpty(item.emp_email);
                    _employeeMasterVM.emp_govt_id_type = StrCleanDataOrEmpty(item.emp_govt_id_type);
                    _employeeMasterVM.emp_govt_id_no = StrCleanDataOrEmpty(item.emp_govt_id_no);
                    _employeeMasterVM.emp_join_date = DateToStringFormat_MM_DD_YYYY(item.emp_join_date);
                    _employeeMasterVM.emp_resign_date = DateToStringFormat_MM_DD_YYYY(item.emp_resign_date);

                    lstEmployeeMasterVM.Add(_employeeMasterVM);
                }
                return lstEmployeeMasterVM.OrderBy(a => a.emp_name).ToList();
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
                    retVal.emp_name = StrCleanDataOrEmpty(employeeData.emp_name);
                    retVal.emp_addr = StrCleanDataOrEmpty(employeeData.emp_addr);
                    retVal.emp_pin = StrCleanDataOrEmpty(employeeData.emp_pin);
                    retVal.emp_phone = StrCleanDataOrEmpty(employeeData.emp_phone);
                    retVal.emp_email = StrCleanDataOrEmpty(employeeData.emp_email);
                    retVal.emp_govt_id_type = StrCleanDataOrEmpty(employeeData.emp_govt_id_type);
                    retVal.emp_govt_id_no = StrCleanDataOrEmpty(employeeData.emp_govt_id_no);
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
        public List<MasterTableHelperMasterVM> LoadMasterTableHelperMasterGrid(int helperID, string operationType = "GET")
        {
            List<MasterTableHelperMasterVM> lstMasterTableHelperMasterVM = new List<MasterTableHelperMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posMasterTableHelperMaster = db.POS_MASTER_TABLE_HELPER;

                var list = posMasterTableHelperMaster.ToList();

                if (helperID > 0) //If we want a single data
                {
                    list.Clear();
                    var custData = posMasterTableHelperMaster.Where(x => x.helper_id == helperID).FirstOrDefault();
                    list.Add(custData);
                }

                foreach (var item in list)
                {
                    MasterTableHelperMasterVM _masterTableHelperMasterVM = new MasterTableHelperMasterVM();
                    _masterTableHelperMasterVM.helper_id = item.helper_id;
                    _masterTableHelperMasterVM.helper_name = StrCleanDataOrEmpty(item.helper_name);
                    _masterTableHelperMasterVM.helper_details = StrCleanDataOrEmpty(item.helper_details);

                    if (operationType.Equals("GET"))
                    {
                        if (item.helper_link_master_table.Trim().Equals("POS_BRAND_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Brand Master";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_COMPANY_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Company Master";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_CUSTOMER_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Customer Master";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_EMPLOYEE_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Employee Master";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_PRODUCT_GROUP_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Product Group Master";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_PRODUCT_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Product Master";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_WAREHOUSE_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Warehouse Master";
                        }
                        else
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "NA";
                        }


                        if (item.helper_active) //Boolean Field
                        {
                            _masterTableHelperMasterVM.helper_active = "Helper Active";
                        }
                        else
                        {
                            _masterTableHelperMasterVM.helper_active = "Helper Deactive";
                        }
                    }

                    if (operationType.Equals("EDIT"))
                    {
                        if (item.helper_link_master_table.Trim().Equals("POS_BRAND_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Brand";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_COMPANY_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Company";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_CUSTOMER_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Customer";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_EMPLOYEE_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Employee";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_PRODUCT_GROUP_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "ProductGroup";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_PRODUCT_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Product";
                        }
                        else if (item.helper_link_master_table.Trim().Equals("POS_WAREHOUSE_MASTER"))
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "Warehouse";
                        }
                        else
                        {
                            _masterTableHelperMasterVM.helper_link_master_table = "NA";
                        }


                        if (item.helper_active) //Boolean Field
                        {
                            _masterTableHelperMasterVM.helper_active = "true";
                        }
                        else
                        {
                            _masterTableHelperMasterVM.helper_active = "false";
                        }
                    }

                    lstMasterTableHelperMasterVM.Add(_masterTableHelperMasterVM);
                }
                return lstMasterTableHelperMasterVM.OrderBy(a => a.helper_name).ToList();
            }
        }

        //Fetch Helper Details for Destination Tables
        public List<MasterTableHelperMasterVM> FetchMasterTableHelperList(string helperLinkMasterTable)
        {   //The parameter must be passed as actual name of the master table

            List<MasterTableHelperMasterVM> lstMasterTableHelperMasterVM = new List<MasterTableHelperMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posMasterTableHelperMaster = db.POS_MASTER_TABLE_HELPER;

                var list = posMasterTableHelperMaster
                    .Where(x => x.helper_link_master_table.Equals(helperLinkMasterTable)).Select(s => s)
                    .Where(x => x.helper_active == true).ToList();

                foreach (var item in list)
                {
                    MasterTableHelperMasterVM _masterTableHelperMasterVM = new MasterTableHelperMasterVM();
                    _masterTableHelperMasterVM.helper_id = item.helper_id;
                    _masterTableHelperMasterVM.helper_name = StrCleanDataOrEmpty(item.helper_name);
                    //_masterTableHelperMasterVM.helper_details = item.helper_details.Trim();
                    _masterTableHelperMasterVM.helper_link_master_table = StrCleanDataOrEmpty(item.helper_link_master_table);
                    //_masterTableHelperMasterVM.helper_active = item.helper_active;

                    lstMasterTableHelperMasterVM.Add(_masterTableHelperMasterVM);
                }
                return lstMasterTableHelperMasterVM.OrderBy(a => a.helper_name).ToList();
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
                    //Filtering the Master Table Data
                    if (helperData.helper_link_master_table.Trim().Equals("Brand"))
                    {
                        helperData.helper_link_master_table = "POS_BRAND_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Company"))
                    {
                        helperData.helper_link_master_table = "POS_COMPANY_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Customer"))
                    {
                        helperData.helper_link_master_table = "POS_CUSTOMER_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Employee"))
                    {
                        helperData.helper_link_master_table = "POS_EMPLOYEE_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("ProductGroup"))
                    {
                        helperData.helper_link_master_table = "POS_PRODUCT_GROUP_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Product"))
                    {
                        helperData.helper_link_master_table = "POS_PRODUCT_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Warehouse"))
                    {
                        helperData.helper_link_master_table = "POS_WAREHOUSE_MASTER";
                    }
                    else
                    {
                        helperData.helper_link_master_table = "NA";
                    }

                    //Filtering the Helper Active Data
                    if (helperData.helper_active) //Boolean Field
                    {
                        helperData.helper_active = true;
                    }
                    else
                    {
                        helperData.helper_active = false;
                    }

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
                    retVal.helper_name = StrCleanDataOrEmpty(helperData.helper_name);
                    retVal.helper_details = StrCleanDataOrEmpty(helperData.helper_details);

                    //retVal.helper_link_master_table = helperData.helper_link_master_table.Trim();

                    if (helperData.helper_link_master_table.Trim().Equals("Brand"))
                    {
                        retVal.helper_link_master_table = "POS_BRAND_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Company"))
                    {
                        retVal.helper_link_master_table = "POS_COMPANY_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Customer"))
                    {
                        retVal.helper_link_master_table = "POS_CUSTOMER_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Employee"))
                    {
                        retVal.helper_link_master_table = "POS_EMPLOYEE_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("ProductGroup"))
                    {
                        retVal.helper_link_master_table = "POS_PRODUCT_GROUP_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Product"))
                    {
                        retVal.helper_link_master_table = "POS_PRODUCT_MASTER";
                    }
                    else if (helperData.helper_link_master_table.Trim().Equals("Warehouse"))
                    {
                        retVal.helper_link_master_table = "POS_WAREHOUSE_MASTER";
                    }
                    else
                    {
                        retVal.helper_link_master_table = "NA";
                    }

                    //Filtering the Helper Active Data
                    if (helperData.helper_active) //Boolean Field
                    {
                        retVal.helper_active = true;
                    }
                    else
                    {
                        retVal.helper_active = false;
                    }
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
                    _productGroupMasterVM.prod_grp_name = StrCleanDataOrEmpty(item.prod_grp_name);
                    _productGroupMasterVM.prod_grp_type = StrCleanDataOrEmpty(item.prod_grp_type);

                    lstProductGroupMasterVM.Add(_productGroupMasterVM);
                }
                return lstProductGroupMasterVM.OrderBy(a => a.prod_grp_name).ToList();
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
                    retVal.prod_grp_name = StrCleanDataOrEmpty(prodGrpData.prod_grp_name);
                    retVal.prod_grp_type = StrCleanDataOrEmpty(prodGrpData.prod_grp_type);

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
        public ProductMasterVM LoadProductMasterGrid(int prodId = 0, string operation = "GET")
        {
            List<ProductMasterData> lstProductMasterData = new List<ProductMasterData>();

            using (var db = new xandaposEntities())
            {
                var posProductMaster = db.POS_PRODUCT_MASTER;
                var list = posProductMaster.ToList();

                if (prodId > 0)
                {
                    list.Clear();
                    var productList = posProductMaster.Where(x => x.product_id == prodId).FirstOrDefault();
                    list.Add(productList);
                }

                foreach (var item in list)
                {
                    ProductMasterData _productMasterData = new ProductMasterData();
                    _productMasterData.product_id = item.product_id;
                    _productMasterData.product_name = StrCleanDataOrEmpty(item.product_name);

                    string prodTypeHelperName = "";
                    try
                    {
                        if (operation.Equals("GET"))
                        {
                            //If we push item.product_type = null or it gets any garbage value
                            prodTypeHelperName = FetchMasterTableHelperList("POS_PRODUCT_MASTER")
                                                     .Where(x => x.helper_id == item.product_type).FirstOrDefault().helper_name;
                        }
                        if (operation.Equals("EDIT"))
                        {
                            if (item.product_type == null)
                                prodTypeHelperName = "NA";
                            else
                                prodTypeHelperName = item.product_type.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (operation.Equals("GET"))
                        {
                            prodTypeHelperName = "";
                        }
                        if (operation.Equals("EDIT"))
                        {
                            prodTypeHelperName = "NA";
                        }
                    }
                    _productMasterData.product_type_name = StrCleanDataOrEmpty(prodTypeHelperName);

                    string prodGroupHelperName = "";
                    try
                    {
                        if (operation.Equals("GET"))
                        {
                            if (item.product_group == null)
                            {
                                prodGroupHelperName = "";
                            }
                            else
                            {
                                prodGroupHelperName = LoadProductGroupMasterGrid(item.product_group.GetValueOrDefault()).FirstOrDefault().prod_grp_name;
                            }
                        }
                        if (operation.Equals("EDIT"))
                        {
                            if (item.product_group == null)
                                prodGroupHelperName = "NA";
                            else
                                prodGroupHelperName = item.product_group.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (operation.Equals("GET"))
                        {
                            prodGroupHelperName = "";
                        }
                        if (operation.Equals("EDIT"))
                        {
                            prodGroupHelperName = "NA";
                        }
                    }
                    _productMasterData.product_group_name = StrCleanDataOrEmpty(prodGroupHelperName);

                    string companyNameHelper = "";
                    try
                    {
                        if (operation.Equals("GET"))
                        {
                            companyNameHelper = FetchCompanyList().mainCompanyData.Where(x => x.comp_id == item.product_company.GetValueOrDefault()).FirstOrDefault().comp_name;
                        }
                        if (operation.Equals("EDIT"))
                        {
                            if (item.product_company == null)
                                companyNameHelper = "NA";
                            else
                                companyNameHelper = item.product_company.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (operation.Equals("GET"))
                        {
                            companyNameHelper = "";
                        }
                        if (operation.Equals("EDIT"))
                        {
                            companyNameHelper = "NA";
                        }
                    }
                    _productMasterData.product_company_name = StrCleanDataOrEmpty(companyNameHelper);

                    _productMasterData.product_details = StrCleanDataOrEmpty(item.product_details);

                    if (string.IsNullOrEmpty(item.product_image_link))
                        _productMasterData.product_image_link = "NO IMAGE LINKED";
                    else
                        _productMasterData.product_image_link = StrCleanDataOrEmpty(item.product_image_link);

                    _productMasterData.product_code = StrCleanDataOrEmpty(item.product_code);
                    _productMasterData.product_default_cost = item.product_default_cost;

                    lstProductMasterData.Add(_productMasterData);
                }

                ProductMasterVM _productMasterVM = new ProductMasterVM();
                _productMasterVM.mainProductData = lstProductMasterData.OrderBy(a => a.product_name).ToList();
                _productMasterVM.companyDetails = FetchCompanyList().mainCompanyData;
                _productMasterVM.prodGrpDetails = LoadProductGroupMasterGrid(0);
                _productMasterVM.helperDetails = FetchMasterTableHelperList("POS_PRODUCT_MASTER");

                return _productMasterVM;
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
                    retVal.product_name = StrCleanDataOrEmpty(prodData.product_name);
                    retVal.product_type = prodData.product_type;
                    retVal.product_group = prodData.product_group;
                    retVal.product_company = prodData.product_company;
                    retVal.product_details = StrCleanDataOrEmpty(prodData.product_details);
                    if (string.IsNullOrEmpty(prodData.product_image_link))
                        retVal.product_image_link = "NO IMAGE LINKED";
                    else
                        retVal.product_image_link = StrCleanDataOrEmpty(prodData.product_image_link);
                    retVal.product_code = StrCleanDataOrEmpty(prodData.product_code);
                    retVal.product_default_cost = prodData.product_default_cost;
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

        #region TAX MASTER (CURRENTLY NO SCREEN - WILL BE USED AS HELPER ONLY)
        public List<TaxMasterVM> LoadTaxMasterList()
        {
            List<TaxMasterVM> _taxMasterList = new List<TaxMasterVM>();
            using (var db = new xandaposEntities())
            {
                //Get only active Tax details only
                var taxMaster = db.POS_TAX_MASTER.Where(x => x.tax_active_status == true).ToList();
                TaxMasterVM taxMasterVM = new TaxMasterVM();

                foreach (var item in taxMaster)
                {
                    taxMasterVM.tax_id = item.tax_id;
                    taxMasterVM.tax_name = StrCleanDataOrEmpty(item.tax_name);
                    taxMasterVM.tax_percent = item.tax_percent;
                    taxMasterVM.tax_description = StrCleanDataOrEmpty(item.tax_description);
                    taxMasterVM.tax_active_status = item.tax_active_status;

                    _taxMasterList.Add(taxMasterVM);
                }
            }
            return _taxMasterList.OrderBy(a => a.tax_name).ToList();
        }

        #endregion

        #region WAREHOUSE MASTER
        //Load Warehouse Grid
        public List<WarehouseMasterVM> LoadWarehouseMasterGrid(int warehouseId = 0)
        {
            List<WarehouseMasterVM> lstWarehouseMasterVM = new List<WarehouseMasterVM>();

            using (var db = new xandaposEntities())
            {
                var posWarehouseMaster = db.POS_WAREHOUSE_MASTER;
                var list = posWarehouseMaster.ToList();

                if (warehouseId > 0)
                {
                    list.Clear();
                    var warehouseData = posWarehouseMaster.Where(x => x.warehouse_id == warehouseId).FirstOrDefault();
                    list.Add(warehouseData);
                }

                foreach (var item in list)
                {
                    WarehouseMasterVM _warehouseMasterVM = new WarehouseMasterVM();
                    _warehouseMasterVM.warehouse_id = item.warehouse_id;
                    _warehouseMasterVM.warehouse_name = StrCleanDataOrEmpty(item.warehouse_name);
                    _warehouseMasterVM.warehouse_address = StrCleanDataOrEmpty(item.warehouse_address);
                    _warehouseMasterVM.warehouse_pin = StrCleanDataOrEmpty(item.warehouse_pin);
                    _warehouseMasterVM.warehouse_phone = StrCleanDataOrEmpty(item.warehouse_phone);
                    _warehouseMasterVM.warehouse_code = StrCleanDataOrEmpty(item.warehouse_code);

                    lstWarehouseMasterVM.Add(_warehouseMasterVM);
                }
                return lstWarehouseMasterVM.OrderBy(a => a.warehouse_name).ToList();
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
                    retVal.warehouse_name = StrCleanDataOrEmpty(warehouseData.warehouse_name);
                    retVal.warehouse_address = StrCleanDataOrEmpty(warehouseData.warehouse_address);
                    retVal.warehouse_pin = StrCleanDataOrEmpty(warehouseData.warehouse_pin);
                    retVal.warehouse_phone = StrCleanDataOrEmpty(warehouseData.warehouse_phone);
                    retVal.warehouse_code = StrCleanDataOrEmpty(warehouseData.warehouse_code);

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


        #region COMMON HELPER METHOD
        string StrCleanDataOrEmpty(string strData)
        {
            return string.IsNullOrEmpty(strData) ? "" : strData.Trim();
        }

        string DateToStringFormat_MM_DD_YYYY(DateTime? dateTimeValue)
        {
            if (dateTimeValue == null)
            {
                return "";
            }
            else
            {
                return dateTimeValue.GetValueOrDefault().ToString("MM/dd/yyyy");
            }
        }

        #endregion
    }
}

