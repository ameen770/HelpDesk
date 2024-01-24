using Azure.Core;
using HelpDesk.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace HelpDesk.WebUI.Models
{
    public partial class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public virtual ICollection<ClientRequest>? ClientRequests { get; set; } = new List<ClientRequest>();
    }
}
