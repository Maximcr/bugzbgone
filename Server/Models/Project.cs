using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts;

namespace Models
{
    public class Project : IDates
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }
        public virtual ICollection<UserProfile> Users { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}