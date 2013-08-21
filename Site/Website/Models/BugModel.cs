using System.ComponentModel.DataAnnotations;
using Models;

namespace Website.Models
{
    public class BugModel
    {
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Priority")]
        public Prioirty Priority { get; set; }

        [Display(Name = "Assigned To")]
        public string AssignedToName { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Creator Name")]
        public string CreatorName { get; set; }

        [Display(Name = "Closed")]
        public bool Closed { get; set; }

        [Display(Name = "Solved")]
        public bool Solved { get; set; }

        public int Id { get; set; }
    }
}