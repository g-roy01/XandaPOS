USE [xandapos]
GO
DELETE FROM [dbo].[POS_WAREHOUSE_MASTER]
GO
DELETE FROM [dbo].[POS_TAX_MASTER]
GO
DELETE FROM [dbo].[pos_PurchaseOrder_Sheet]
GO
DELETE FROM [dbo].[pos_PurchaseOrder_Main]
GO
DELETE FROM [dbo].[POS_PRODUCT_MASTER]
GO
DELETE FROM [dbo].[POS_PRODUCT_GROUP_MASTER]
GO
DELETE FROM [dbo].[POS_MASTER_TABLE_HELPER]
GO
DELETE FROM [dbo].[POS_EMPLOYEE_MASTER]
GO
DELETE FROM [dbo].[POS_CUSTOMER_MASTER]
GO
DELETE FROM [dbo].[POS_COMPANY_MASTER]
GO
DELETE FROM [dbo].[POS_BRAND_MASTER]
GO
SET IDENTITY_INSERT [dbo].[POS_BRAND_MASTER] ON 

INSERT [dbo].[POS_BRAND_MASTER] ([brand_id], [brand_name], [brand_company], [brand_product_group]) VALUES (1, N'Br1                                               ', 0, 6)
INSERT [dbo].[POS_BRAND_MASTER] ([brand_id], [brand_name], [brand_company], [brand_product_group]) VALUES (2, N'Br2                                               ', 2, NULL)
INSERT [dbo].[POS_BRAND_MASTER] ([brand_id], [brand_name], [brand_company], [brand_product_group]) VALUES (3, N'adfa1                                             ', 2, NULL)
INSERT [dbo].[POS_BRAND_MASTER] ([brand_id], [brand_name], [brand_company], [brand_product_group]) VALUES (5, N'Br2                                               ', 0, NULL)
INSERT [dbo].[POS_BRAND_MASTER] ([brand_id], [brand_name], [brand_company], [brand_product_group]) VALUES (7, N'adasdas                                           ', 1, 2)
SET IDENTITY_INSERT [dbo].[POS_BRAND_MASTER] OFF
SET IDENTITY_INSERT [dbo].[POS_COMPANY_MASTER] ON 

INSERT [dbo].[POS_COMPANY_MASTER] ([comp_id], [comp_name], [comp_address], [comp_pin], [comp_type], [comp_regn_no]) VALUES (1, N'KFC                                               ', N'ABC                                                                                                                                                                                                     ', N'1234      ', 3, NULL)
INSERT [dbo].[POS_COMPANY_MASTER] ([comp_id], [comp_name], [comp_address], [comp_pin], [comp_type], [comp_regn_no]) VALUES (2, N'KFC India Supplier                                ', N'Kolkta                                                                                                                                                                                                  ', N'121       ', 4, NULL)
INSERT [dbo].[POS_COMPANY_MASTER] ([comp_id], [comp_name], [comp_address], [comp_pin], [comp_type], [comp_regn_no]) VALUES (3, N'yhoiyi                                            ', N'yiouio                                                                                                                                                                                                  ', N'uiouo     ', 3, N'                    ')
INSERT [dbo].[POS_COMPANY_MASTER] ([comp_id], [comp_name], [comp_address], [comp_pin], [comp_type], [comp_regn_no]) VALUES (4, N'khko                                              ', N'iuuoi                                                                                                                                                                                                   ', N'oui       ', 3, NULL)
INSERT [dbo].[POS_COMPANY_MASTER] ([comp_id], [comp_name], [comp_address], [comp_pin], [comp_type], [comp_regn_no]) VALUES (8, N'Supplier Generic 1                                ', N'ABC                                                                                                                                                                                                     ', N'147       ', 4, NULL)
INSERT [dbo].[POS_COMPANY_MASTER] ([comp_id], [comp_name], [comp_address], [comp_pin], [comp_type], [comp_regn_no]) VALUES (9, N'Supplier Generic 2                                ', N'ABC                                                                                                                                                                                                     ', N'4424      ', 4, NULL)
SET IDENTITY_INSERT [dbo].[POS_COMPANY_MASTER] OFF
SET IDENTITY_INSERT [dbo].[POS_CUSTOMER_MASTER] ON 

INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (4, N'Raja                                              ', N'Nimta                                                                                                                                                                                                   ', N'21381     ', N'218828         ', N'dasjha@sjas.com                                   ')
INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (5, N'Roy                                               ', N'Baguiati                                                                                                                                                                                                ', N'132131    ', N'132131         ', N'abc@ddcd.com                                      ')
INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (6, N'JK                                                ', N'sadasdas                                                                                                                                                                                                ', N'213121321 ', N'12321321321    ', N'adadas@ersdfs.com                                 ')
INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (7, N'Manikaran                                         ', N'Gurudwara                                                                                                                                                                                               ', NULL, NULL, NULL)
INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (13, N'Srikant                                           ', N'Mumbai                                                                                                                                                                                                  ', NULL, NULL, NULL)
INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (14, N'Chellam                                           ', N'Chennai                                                                                                                                                                                                 ', N'3123421   ', N'21312321921321 ', NULL)
INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (15, N'Bose                                              ', N'Delhi                                                                                                                                                                                                   ', N'88888     ', N'5454545454     ', NULL)
INSERT [dbo].[POS_CUSTOMER_MASTER] ([cust_id], [cust_name], [cust_addr], [cust_pin], [cust_phn], [cust_email]) VALUES (16, N'Raji                                              ', N'Srilanka                                                                                                                                                                                                ', N'213331    ', N'213434283      ', NULL)
SET IDENTITY_INSERT [dbo].[POS_CUSTOMER_MASTER] OFF
SET IDENTITY_INSERT [dbo].[POS_EMPLOYEE_MASTER] ON 

INSERT [dbo].[POS_EMPLOYEE_MASTER] ([emp_id], [emp_name], [emp_addr], [emp_pin], [emp_phone], [emp_govt_id_type], [emp_govt_id_no], [emp_join_date], [emp_resign_date], [emp_email]) VALUES (1, N'hjASD                                             ', N'adsfasdf                                                                                                                                                                                                ', N'121321    ', N'2132132        ', N'asdas                                             ', NULL, CAST(N'2021-06-01' AS Date), NULL, N'ada@fdd.com                                       ')
INSERT [dbo].[POS_EMPLOYEE_MASTER] ([emp_id], [emp_name], [emp_addr], [emp_pin], [emp_phone], [emp_govt_id_type], [emp_govt_id_no], [emp_join_date], [emp_resign_date], [emp_email]) VALUES (2, N'aaadf                                             ', N'dsfads                                                                                                                                                                                                  ', N'111       ', N'11223          ', N'                                                  ', N'                              ', CAST(N'2021-02-01' AS Date), NULL, N'                                                  ')
INSERT [dbo].[POS_EMPLOYEE_MASTER] ([emp_id], [emp_name], [emp_addr], [emp_pin], [emp_phone], [emp_govt_id_type], [emp_govt_id_no], [emp_join_date], [emp_resign_date], [emp_email]) VALUES (3, N'dfds                                              ', N'dsfds                                                                                                                                                                                                   ', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[POS_EMPLOYEE_MASTER] OFF
SET IDENTITY_INSERT [dbo].[POS_MASTER_TABLE_HELPER] ON 

INSERT [dbo].[POS_MASTER_TABLE_HELPER] ([helper_id], [helper_name], [helper_link_master_table], [helper_details], [helper_active]) VALUES (2, N'Finished Product                                  ', N'POS_PRODUCT_MASTER                                ', N'asdasdas                                                                                                                                              ', 1)
INSERT [dbo].[POS_MASTER_TABLE_HELPER] ([helper_id], [helper_name], [helper_link_master_table], [helper_details], [helper_active]) VALUES (3, N'Vendor                                            ', N'POS_COMPANY_MASTER                                ', N'sadadas                                                                                                                                               ', 1)
INSERT [dbo].[POS_MASTER_TABLE_HELPER] ([helper_id], [helper_name], [helper_link_master_table], [helper_details], [helper_active]) VALUES (4, N'Supplier                                          ', N'POS_COMPANY_MASTER                                ', N'Supplier                                                                                                                                              ', 1)
INSERT [dbo].[POS_MASTER_TABLE_HELPER] ([helper_id], [helper_name], [helper_link_master_table], [helper_details], [helper_active]) VALUES (8, N'dfafdas                                           ', N'POS_BRAND_MASTER                                  ', N'asdasda                                                                                                                                               ', 1)
INSERT [dbo].[POS_MASTER_TABLE_HELPER] ([helper_id], [helper_name], [helper_link_master_table], [helper_details], [helper_active]) VALUES (9, N'Processing Product                                ', N'POS_PRODUCT_MASTER                                ', NULL, 1)
SET IDENTITY_INSERT [dbo].[POS_MASTER_TABLE_HELPER] OFF
SET IDENTITY_INSERT [dbo].[POS_PRODUCT_GROUP_MASTER] ON 

INSERT [dbo].[POS_PRODUCT_GROUP_MASTER] ([prod_grp_id], [prod_grp_name], [prod_grp_type]) VALUES (1, N'Burger                                            ', N'Fast Food Dry                                                                                       ')
INSERT [dbo].[POS_PRODUCT_GROUP_MASTER] ([prod_grp_id], [prod_grp_name], [prod_grp_type]) VALUES (2, N'Cold Drink                                        ', N'Fast Food Soft Drink                                                                                ')
INSERT [dbo].[POS_PRODUCT_GROUP_MASTER] ([prod_grp_id], [prod_grp_name], [prod_grp_type]) VALUES (6, N'Alcoholic Drink                                   ', N'Fast Food Hard Drink                                                                                ')
INSERT [dbo].[POS_PRODUCT_GROUP_MASTER] ([prod_grp_id], [prod_grp_name], [prod_grp_type]) VALUES (7, N'sadasda                                           ', N'asdasda                                                                                             ')
INSERT [dbo].[POS_PRODUCT_GROUP_MASTER] ([prod_grp_id], [prod_grp_name], [prod_grp_type]) VALUES (9, N'ABC                                               ', NULL)
SET IDENTITY_INSERT [dbo].[POS_PRODUCT_GROUP_MASTER] OFF
SET IDENTITY_INSERT [dbo].[POS_PRODUCT_MASTER] ON 

INSERT [dbo].[POS_PRODUCT_MASTER] ([product_id], [product_name], [product_type], [product_group], [product_company], [product_details], [product_image_link], [product_code], [product_default_cost]) VALUES (2, N'Product 3                                         ', 2, 2, 2, N'                                                                                                                                                      ', N'NO IMAGE LINKED                                                                                                                                       ', N'PR002     ', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[POS_PRODUCT_MASTER] ([product_id], [product_name], [product_type], [product_group], [product_company], [product_details], [product_image_link], [product_code], [product_default_cost]) VALUES (3, N'Product 2                                         ', 2, 6, 3, N'                                                                                                                                                      ', N'NO IMAGE LINKED                                                                                                                                       ', N'PR003     ', CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[POS_PRODUCT_MASTER] ([product_id], [product_name], [product_type], [product_group], [product_company], [product_details], [product_image_link], [product_code], [product_default_cost]) VALUES (4, N'Product 1                                         ', 2, 9, 4, N'                                                                                                                                                      ', N'NO IMAGE LINKED                                                                                                                                       ', N'PR001     ', CAST(250.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[POS_PRODUCT_MASTER] OFF
SET IDENTITY_INSERT [dbo].[POS_TAX_MASTER] ON 

INSERT [dbo].[POS_TAX_MASTER] ([tax_id], [tax_name], [tax_description], [tax_percent], [tax_active_status]) VALUES (1, N'VAT @ 15%', NULL, CAST(15.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[POS_TAX_MASTER] ([tax_id], [tax_name], [tax_description], [tax_percent], [tax_active_status]) VALUES (2, N'SGST @ 10%', NULL, CAST(10.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[POS_TAX_MASTER] ([tax_id], [tax_name], [tax_description], [tax_percent], [tax_active_status]) VALUES (3, N'CGST @ 10%', NULL, CAST(10.00 AS Decimal(5, 2)), 1)
SET IDENTITY_INSERT [dbo].[POS_TAX_MASTER] OFF
SET IDENTITY_INSERT [dbo].[POS_WAREHOUSE_MASTER] ON 

INSERT [dbo].[POS_WAREHOUSE_MASTER] ([warehouse_id], [warehouse_name], [warehouse_address], [warehouse_pin], [warehouse_phone], [warehouse_code]) VALUES (2, N'Warehouse 2                                       ', N'asdas                                                                                                                                                                                                   ', N'adsfaes   ', N'asda           ', N'          ')
INSERT [dbo].[POS_WAREHOUSE_MASTER] ([warehouse_id], [warehouse_name], [warehouse_address], [warehouse_pin], [warehouse_phone], [warehouse_code]) VALUES (3, N'Warehouse 1                                       ', N'adas                                                                                                                                                                                                    ', N'21312     ', N'21321          ', N'          ')
INSERT [dbo].[POS_WAREHOUSE_MASTER] ([warehouse_id], [warehouse_name], [warehouse_address], [warehouse_pin], [warehouse_phone], [warehouse_code]) VALUES (4, N'Warehouse 3                                       ', N'ABC                                                                                                                                                                                                     ', N'214434    ', N'34534534       ', N'4353454334')
SET IDENTITY_INSERT [dbo].[POS_WAREHOUSE_MASTER] OFF
