using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BugzbgoneDb : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
