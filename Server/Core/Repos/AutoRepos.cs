
using System.Data.Entity;
using Catel.Data.Repositories;
using Models;
using Contracts;
using Data;
using Core.Repos.Interfaces;
namespace Core.Repos
{
    public partial class BugRepository : EntityRepositoryBase<Bug, int>, IBugRepository
	{
		 public BugRepository(BugzbgoneDb dbContext) 
		 : base(dbContext)
         {
         }
	} 

	    public partial class UserProfileRepository : EntityRepositoryBase<UserProfile, int>, IUserProfileRepository
	{
		 public UserProfileRepository(BugzbgoneDb dbContext) 
		 : base(dbContext)
         {
         }
	} 

	    public partial class CommentRepository : EntityRepositoryBase<Comment, int>, ICommentRepository
	{
		 public CommentRepository(BugzbgoneDb dbContext) 
		 : base(dbContext)
         {
         }
	} 

	}
