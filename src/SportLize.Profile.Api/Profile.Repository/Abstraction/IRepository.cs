using System;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Repository.Model;

namespace SportLize.Profile.Api.Profile.Repository.Abstraction
{
	public interface IRepository
	{
        Task<int> SaveChanges();

        #region CREATE
        Task CreateUser(Actor actor, string nickname, string name, string surname, string password, string description, DateTime dateOfBorn);
        Task CreateComment(string text, DateTime pubblicationDate, Post post);
        Task CreatePost(string mediaBase64, DateTime pubblicationDate, string? description, User user);
        Task CreatePostInterest(bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing, Post post);
        Task CreateUserInterest(bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing, User user);
        #endregion

        #region ADD
        Task AddFollower(string nicknameUser, string nicknameFollower);
        Task AddFollowing(string nicknameUser, string nicknameFollowing);
        Task AddLikeComment(int id);
        Task AddLikePost(int id);
        #endregion

        #region UPDATE
        Task UpdateUser(string nickname, string name, string surname, string password, string description, DateTime dateOfBorn);
        Task UpdatePostInterestOfPost(int id, bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing);
        Task UpdateUserInterest(int id, bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing);
        #endregion

        #region GET
        #region SPECIFIC
        Task<User?> GetUser(string nickname);
        Task<User?> GetUser(int id);
        Task<Post?> GetPost(int id);
        Task<Comment?> GetComment(int id);
        Task<PostInterest?> GetPostInterestFromPostId(int id);
        Task<UserInterest?> GetUserInterestFromUserNickname(string nickname);
        #endregion

        #region GENERAL FOR ALL
        Task<IEnumerable<User>?> GetAllUser();
        Task<IEnumerable<Post>?> GetAllPost();
        Task<IEnumerable<Comment>?> GetAllComment();
        Task<IEnumerable<UserInterest>?> GetAllUserInterest();
        Task<IEnumerable<PostInterest>?> GetAllPostInterest();
        #endregion

        #region SPECIFIC FOR ALL
        Task<IEnumerable<User>?> GetAllFollowerOfUser(string nickname);
        Task<IEnumerable<User>?> GetAllFollowingOfUser(string nickname);
        Task<IEnumerable<Post>?> GetAllPostOfUser(string nickname);
        Task<IEnumerable<Comment>?> GetAllCommentOfPost(int id);
        #endregion
        #endregion

        #region REMOVE
        Task RemoveUser(string nickname);
        Task RemovePost(int id);
        Task RemoveComment(int id);
        Task RemovePostInterest(int id);
        Task RemoveUserInterest(string nickname);
        #endregion
    }
}

