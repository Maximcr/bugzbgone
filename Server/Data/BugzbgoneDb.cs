using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Contracts;
using Models;

namespace Data
{
    public class BugzbgoneDb : DbContext
    {
        public BugzbgoneDb()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;

        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasMany(x => x.CreatedBugs).WithRequired(x => x.Creator);
            modelBuilder.Entity<Project>().HasMany(x => x.Bugs).WithRequired(x => x.Project);
            modelBuilder.Entity<Project>().HasMany(x => x.Users).WithMany(x => x.Projects);
            modelBuilder.Entity<UserProfile>()
                .HasMany(x => x.Assingedbugs)
                .WithRequired(x => x.AssignedTo)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Comment>()
                .HasRequired(x => x.BaseItem)
                .WithMany(x => x.Comments)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Comment>()
                .HasRequired(x => x.Creator)
                .WithMany(x => x.Comments)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (
                DbEntityEntry item in
                    ChangeTracker.Entries()
                        .Where(x => x.State == EntityState.Added && x.Entity.GetType() == typeof (IDates)))
            {
                ((IDates) item).CreateDate = DateTime.UtcNow;
                ((IDates) item).ModifyDate = DateTime.UtcNow;
            }
            foreach (
                DbEntityEntry item in
                    ChangeTracker.Entries()
                        .Where(x => x.State == EntityState.Modified && x.Entity.GetType() == typeof (IDates)))
            {
                ((IDates) item).ModifyDate = DateTime.UtcNow;
            }
            return base.SaveChanges();
        }
    }
}