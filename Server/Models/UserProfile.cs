using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public virtual ICollection<Bug> CreatedBugs { get; set; }
        public virtual ICollection<Bug> Assingedbugs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } 


    }
}
