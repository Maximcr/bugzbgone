
using Catel.IoC;
using Core.Repos;
using Core.Repos.Interfaces;
using Data;
namespace Core
{
	internal static partial class IoC
	{
		public static void AutoRegisterRepositories()
		{
            ServiceLocator.Default.RegisterType<IBugRepository, BugRepository>();
	            ServiceLocator.Default.RegisterType<IProjectRepository, ProjectRepository>();
	            ServiceLocator.Default.RegisterType<IUserProfileRepository, UserProfileRepository>();
	            ServiceLocator.Default.RegisterType<ICommentRepository, CommentRepository>();
			}
	}
}