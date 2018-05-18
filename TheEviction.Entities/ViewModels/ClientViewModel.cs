#region Includes
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
#endregion

namespace TheEviction.Entities.ViewModels
{
    public partial class ClientViewModel
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Client Number is a required Field")]
        [Display(Name = "Client Number")]
        public int ClientNum { get; set; }

        [Required(ErrorMessage = "Client Name is a required Field")]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Display(Name = "Company Name")]
        public int CompanyTypeId { get; set; }

        [Display(Name = "Facility")]
        public int? FacilityId { get; set; }

        [Display(Name = "Address")]
        public int? AddressId { get; set; }

        [Display(Name = "Contact Name")]
        public int? ContactId { get; set; }

        [Display(Name = "Phone")]
        public int? PhoneId { get; set; }

        [Display(Name = "County")]
        public int CountyId { get; set; }

        [Required(ErrorMessage = "Notes is a required Field")]
        [Display(Name = "Notes")]
        [StringLength(512)]
        public string Notes { get; set; }

        [Display(Name = "Active Flag")]
        public bool IsActiveFlg { get; set; }

        [Display(Name = "Office Access Flag")]
        public bool? IsOfficeAccessFlg { get; set; }

        [Display(Name = "Create Date")]
        public DateTime? CreatedDt { get; set; } = DateTime.UtcNow; // I am using the CreatedDate as when this was made unless someone overrrides it. value for now based on the Universal Time Zone.

        [Display(Name = "Created By")]
        public int? CreatedBy { get; set; } //= TODO @User.Identity.Name!

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDt { get; set; }

        [Display(Name = "Modified By")]
        public int? ModifiedBy { get; set; }
    }
}
