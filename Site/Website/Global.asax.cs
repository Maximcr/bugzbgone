using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Catel.IoC;
using Catel.Mvc;
using Contracts;
using Core;
using Core.Repos.Interfaces;
using WebMatrix.WebData;

namespace Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BugzbgoneDb>());
            //var db = new BugzbgoneDb();
            //db.Database.Initialize(true);

            Bootstrap.Start();
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfiles", "Id", "UserName", true);
            DependencyInjectionConfig.RegisterServiceLocatorAsDependencyResolver();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            CheckRolesAndMaxim();
        }

        private void CheckRolesAndMaxim()
        {
            var roles = (SimpleRoleProvider) Roles.Provider;
            if (!roles.RoleExists("Team Leader"))
                roles.CreateRole("Team Leader");
            if (!roles.RoleExists("Team Member"))
                roles.CreateRole("Team Member");
            var _uow = ServiceLocator.Default.ResolveType<IBugzbgoneUoW>();
            if (!_uow.GetRepository<IUserProfileRepository>().GetAll().Any(x => x.UserName == "Maxim"))
            {
                var membership = (SimpleMembershipProvider) Membership.Provider;
                membership.CreateUserAndAccount("Maxim", "mixam111");
                roles.AddUsersToRoles(new[] {"Maxim"}, new[] {"Team Leader"});
            }
        }
    }
}