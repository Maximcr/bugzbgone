using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Core.Repos.Interfaces;
using Models;
using WebMatrix.WebData;
using Website.Models;

namespace Website.Controllers
{
    public class BugController : BaseController
    {
        //
        // GET: /Bug/

        public ActionResult Index()
        {
            using (var bugrepo = _uow.GetRepository<IBugRepository>())
            {
                return
                    View(
                        bugrepo.GetQuery()
                            .Include(x => x.Creator)
                            .Include(z => z.AssignedTo)
                            .Include(x => x.Project)
                            .ToList());
            }
        }

        public ActionResult CreateTeamMember()
        {
            return View(new TeamMemberModel());
        }

        [HttpPost]
        public ActionResult CreateTeamMember(TeamMemberModel teamMemberModel)
        {
            var membership = (SimpleMembershipProvider) Membership.Provider;
            membership.CreateUserAndAccount(teamMemberModel.UserName, teamMemberModel.Password);
            var roles = (SimpleRoleProvider) Roles.Provider;
            roles.AddUsersToRoles(new[] {teamMemberModel.UserName}, new[] {"Team Member"});
            return RedirectToAction("Index");
        }

        public ActionResult CreateProject()
        {
            return View(new ProjectModel());
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectModel projectModel)
        {
            using (var repo = _uow.GetRepository<IProjectRepository>())
            {
                var newproject = new Project();
                newproject.Name = projectModel.Name;
                repo.Add(newproject);
            }
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateNewBug()
        {
            var bugmodel = new Bug();
            ViewData["Priorities"] = bugmodel.Prioirty.ToSelectList();
            var allusers = new List<SelectListItem>();
            _uow.GetRepository<IUserProfileRepository>().GetAll().ToList().ForEach(item => allusers.Add( new SelectListItem(){ Selected = false, Text = item.UserName, Value = item.UserName}));
            ViewData["allusers"] = allusers;
            var allprojects = new List<SelectListItem>();
            _uow.GetRepository<IProjectRepository>().GetAll().ToList().ForEach(item => allprojects.Add(new SelectListItem() { Selected = false, Text = item.Name, Value = item.Name }));
            ViewData["allprojects"] = allprojects;
            return View(new BugModel());
        }

        [HttpPost]
        public ActionResult CreateNewBug(BugModel bugModel)
        {

            using (var repo = _uow.GetRepository<IBugRepository>())
            {
                var newbug = new Bug();
                Project project =
                    _uow.GetRepository<IProjectRepository>().FirstOrDefault(x => x.Name == bugModel.ProjectName);
                UserProfile creator =
                    _uow.GetRepository<IUserProfileRepository>().FirstOrDefault(x => x.UserName == User.Identity.Name);
                UserProfile assignedto =
                    _uow.GetRepository<IUserProfileRepository>()
                        .FirstOrDefault(x => x.UserName == bugModel.AssignedToName);
                newbug.Creator = creator;
                newbug.AssignedTo = assignedto;
                newbug.Description = bugModel.Description;
                newbug.Project = project;
                newbug.Prioirty = bugModel.Priority;
                newbug.Title = bugModel.Title;
                repo.Add(newbug);
            }
            _uow.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ViewBug(int id = 1)
        {
            using (var repo = _uow.GetRepository<IBugRepository>())
            {
                var bugmodel = new BugModel();
                var bug = repo.FirstOrDefault(x => x.Id == id);
                bugmodel.Priority = bug.Prioirty;
                bugmodel.AssignedToName = bug.AssignedTo.UserName;
                bugmodel.Description = bug.Description;
                bugmodel.ProjectName = bug.Project.Name;
                bugmodel.Title = bug.Title;
                bugmodel.CreatorName = bug.Creator.UserName;
                bugmodel.Closed = bug.Closed;
                bugmodel.Solved = bug.Solved;
                return View(bugmodel);
            }
        }
    }
}