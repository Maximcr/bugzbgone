using Models;

namespace Website.Models
{
    public class BugModel
    {
        public string Description { get; set; }
        public Prioirty Priority { get; set; }
        public string AssignedToName { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
    }
}