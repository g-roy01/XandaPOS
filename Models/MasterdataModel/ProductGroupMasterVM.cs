using System.ComponentModel.DataAnnotations;

namespace XandaPOS.Models.MasterdataModel
{
    public class ProductGroupMasterVM
    {
        public int prod_grp_id { get; set; }

        [Required(ErrorMessage = "Please enter a valid Product Group Name.")]
        [StringLength(100, ErrorMessage = "The Product Group Name must be less than {1} characters.")]
        [Display(Name = "Product Group Name:")]
        public string prod_grp_name { get; set; }

        public string prod_grp_type { get; set; }
    }
}