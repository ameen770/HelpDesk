using System.ComponentModel.DataAnnotations;
using HelpDesk.WebUI.Models;
using HelpDesk.WebUI.Enum;

namespace HelpDesk.WebUI.Models
{
    public partial class ClientRequest : GeneralModel
    {
        [Key]
        public int RequestId { get; set; }

        [Display(Name = "Customer Name")]
        public string ClientName { get; set; }

        [Display(Name = "Request Description")]
        public string RequestDescription { get; set; }

        [Display(Name = "Request Type")]
        public string? RequestType { get; set; }

        [Display(Name = "Request Status")]
        public RequestStatus? RStatus { get; set; } = RequestStatus.Waiting;

        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Response Date")]
        public DateTime? ResponseDate { get; set; }

        [Display(Name = "Employee Response")]
        public string? Response { get; set; }

        [Display(Name = "Assigned Employee")]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
