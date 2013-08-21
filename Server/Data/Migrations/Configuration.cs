using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using Models;
using WebMatrix.WebData;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BugzbgoneDb>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugzbgoneDb context)
        {
            UserProfile maximuser = context.UserProfiles.Find(1);
            context.Projects.AddOrUpdate(x => x.Name,
                new[]
                {
                    new Project {Name = "Project A"},
                    new Project {Name = "Project B"},
                    new Project {Name = "En nog een"}
                });
            context.SaveChanges();
            var projectA = context.Projects.FirstOrDefault(x => x.Name == "Project A");
            var projectB = context.Projects.FirstOrDefault(x => x.Name == "Project B");
            context.Bugs.AddOrUpdate(x => x.Title, new[]
            {
                new Bug
                {
                    Project = projectA,
                    AssignedTo = maximuser,
                    Creator = maximuser,
                    Title = "This is a test",
                    Description = "This is the first bug ever seen in the wildernis"
                },
                new Bug
                {
                    Project = projectB,
                    AssignedTo = maximuser,
                    Creator = maximuser,
                    Title = "This is a test3",
                    Description = "This is the first bug ever seen in the wildernis"
                },
                new Bug
                {
                    Project = projectA,
                    AssignedTo = maximuser,
                    Creator = maximuser,
                    Title = "This is a test2",
                    Description = "And a second one appears"
                }
            });
            context.SaveChanges();

            SeedMembership();
        }

        private void SeedMembership()
        {
            //var roles = (SimpleRoleProvider) Roles.Provider;
            //if (!roles.RoleExists("Team Leader"))
            //    roles.CreateRole("Team Leader");
            //if (!roles.RoleExists("Team Member"))
            //    roles.CreateRole("Team Member");
            //var membership = (SimpleMembershipProvider) Membership.Provider;
        }
    }
}