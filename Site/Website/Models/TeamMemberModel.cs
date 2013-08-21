using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class TeamMemberModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}