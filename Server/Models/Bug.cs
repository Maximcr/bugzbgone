using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bug : IDates
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Prioirty Prioirty { get; set; }
        public UserProfile Creator { get; set; }
        public UserProfile AssignedTo { get; set; }
        public Project Project { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool Solved { get; set; }
        public bool Closed { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } 

    }
}
