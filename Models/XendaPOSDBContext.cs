//JUST DUMMY FOR TESTING

//namespace XandaPOS.Edmx
//{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Infrastructure;
//    using System.Data.Entity.Core.Objects;
//    using System.Linq;

//    public partial class XendaPOSDBContext : DbContext
//    {
//        public XendaPOSDBContext()
//            : base("name=xandaposEntities")
//        {
//        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            throw new UnintentionalCodeFirstException();
//        }

//        public virtual DbSet<POS_BRAND_MASTER> POS_BRAND_MASTER { get; set; }
//        public virtual DbSet<POS_COMPANY_MASTER> POS_COMPANY_MASTER { get; set; }
//        public virtual DbSet<POS_CUSTOMER_MASTER> CustomerData { get; set; }
//        public virtual DbSet<POS_EMPLOYEE_MASTER> POS_EMPLOYEE_MASTER { get; set; }
//        public virtual DbSet<POS_MASTER_TABLE_HELPER> POS_MASTER_TABLE_HELPER { get; set; }
//        public virtual DbSet<POS_PRODUCT_GROUP_MASTER> POS_PRODUCT_GROUP_MASTER { get; set; }
//        public virtual DbSet<POS_PRODUCT_MASTER> POS_PRODUCT_MASTER { get; set; }
//        public virtual DbSet<POS_WAREHOUSE_MASTER> POS_WAREHOUSE_MASTER { get; set; }

//        public virtual int sp_AddNewCustomer(string custName, string custAddress, string custPin, string custPhone, string custEmail)
//        {
//            var custNameParameter = custName != null ?
//                new ObjectParameter("custName", custName) :
//                new ObjectParameter("custName", typeof(string));

//            var custAddressParameter = custAddress != null ?
//                new ObjectParameter("custAddress", custAddress) :
//                new ObjectParameter("custAddress", typeof(string));

//            var custPinParameter = custPin != null ?
//                new ObjectParameter("custPin", custPin) :
//                new ObjectParameter("custPin", typeof(string));

//            var custPhoneParameter = custPhone != null ?
//                new ObjectParameter("custPhone", custPhone) :
//                new ObjectParameter("custPhone", typeof(string));

//            var custEmailParameter = custEmail != null ?
//                new ObjectParameter("custEmail", custEmail) :
//                new ObjectParameter("custEmail", typeof(string));

//            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddNewCustomer", custNameParameter, custAddressParameter, custPinParameter, custPhoneParameter, custEmailParameter);
//        }

//        public virtual int sp_AddNewProductGroup(string prodGroupId, string prodGroupName, string prodGroupType)
//        {
//            var prodGroupIdParameter = prodGroupId != null ?
//                new ObjectParameter("prodGroupId", prodGroupId) :
//                new ObjectParameter("prodGroupId", typeof(string));

//            var prodGroupNameParameter = prodGroupName != null ?
//                new ObjectParameter("prodGroupName", prodGroupName) :
//                new ObjectParameter("prodGroupName", typeof(string));

//            var prodGroupTypeParameter = prodGroupType != null ?
//                new ObjectParameter("prodGroupType", prodGroupType) :
//                new ObjectParameter("prodGroupType", typeof(string));

//            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddNewProductGroup", prodGroupIdParameter, prodGroupNameParameter, prodGroupTypeParameter);
//        }

//        public virtual ObjectResult<string> sp_GetNewProdGrpId()
//        {
//            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_GetNewProdGrpId");
//        }
//    }
//}
