using System;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Repository.Model;
using SportLize.Profile.Api.Profile.Shared;

namespace SportLize.Profile.Api.Profile.Business.Abstraction
{
	public interface IBusiness
	{
        #region CREATE
        Task CreateUser(UserDto userDto);
        Task CreateComment(CommentDto commentDto);
        Task CreatePost(PostDto postDto);
        Task CreatePostInterest(PostInterestDto postInterestDto);
        Task CreateUserInterest(UserInterestDto userInterestDto);
        #endregion

        #region ADD
        Task AddFollower(string nicknameUser, string nicknameFollower);
        Task AddFollowing(string nicknameUser, string nicknameFollowing);
        Task AddLikeComment(int id);
        Task AddLikePost(int id);
        #endregion

        #region UPDATE
        Task UpdateUser(UserDto userDto);
        Task UpdatePostInterestOfPost(PostInterestDto postInterestDto);
        Task UpdateUserInterest(UserInterestDto userInterestDto);
        #endregion

        #region GET
        #region SPECIFIC
        Task<UserDto?> GetUser(string nickname);
        Task<PostDto?> GetPost(int id);
        Task<CommentDto?> GetComment(int id);
        Task<PostInterestDto?> GetPostInterestFromPostId(int id);
        Task<UserInterestDto?> GetUserInterestFromUserNickname(string nickname);
        #endregion

        #region GENERAL FOR ALL
        Task<IEnumerable<UserDto>?> GetAllUser();
        Task<IEnumerable<PostDto>?> GetAllPost();
        Task<IEnumerable<CommentDto>?> GetAllComment();
        Task<IEnumerable<UserInterestDto>?> GetAllUserInterest();
        Task<IEnumerable<PostInterestDto>?> GetAllPostInterest();
        #endregion

        #region SPECIFIC FOR ALL
        Task<IEnumerable<UserDto>?> GetAllFollowerOfUser(string nickname);
        Task<IEnumerable<UserDto>?> GetAllFollowingOfUser(string nickname);
        Task<IEnumerable<PostDto>?> GetAllPostOfUser(string nickname);
        Task<IEnumerable<CommentDto>?> GetAllCommentOfPost(int id);
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

