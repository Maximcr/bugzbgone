using Contracts;
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
        public BugzbgoneDb()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasMany(x => x.CreatedBugs).WithRequired(x => x.Creator);
            modelBuilder.Entity<UserProfile>().HasMany(x => x.Assingedbugs).WithRequired(x => x.AssignedTo).WillCascadeOnDelete(false);
            modelBuilder.Entity<Comment>().HasRequired(x => x.BaseItem).WithMany(x => x.Comments).WillCascadeOnDelete(false);
            modelBuilder.Entity<Comment>().HasRequired(x => x.Creator).WithMany(x => x.Comments).WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public override int SaveChanges()
        {

            foreach (IDates item in ChangeTracker.Entries<IDates>().Where(x => x.State == System.Data.EntityState.Added))
            {
                item.CreateDate = DateTime.UtcNow;
                item.ModifyDate = DateTime.UtcNow;
            }
            foreach (IDates item in ChangeTracker.Entries<IDates>().Where(x => x.State == System.Data.EntityState.Modified))
            {
                item.ModifyDate = DateTime.UtcNow;
            }
            return base.SaveChanges();
        }
    }
}
