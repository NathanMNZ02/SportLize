using System;
using Microsoft.AspNetCore.Mvc;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Shared;

namespace SportLize.Profile.Api.Profile.ClientHttp.Abstraction
{
	public interface IClientHttp
	{
        #region CREATE
        Task<IActionResult?> CreateUser(UserDto userDto);

        Task<IActionResult?> CreateComment(CommentDto commentDto);

        Task<IActionResult?> CreatePost(PostDto postDto);

        Task<IActionResult?> CreatePostInterest(PostInterestDto postInterestDto);

        Task<IActionResult?> CreateUserInterest(UserInterestDto userInterestDto);
        #endregion

        #region ADD
        Task<IActionResult?> AddFollower(string nicknameUser, string nicknameFollower);

        Task<IActionResult?> AddFollowing(string nicknameUser, string nicknameFollowing);

        Task<IActionResult?> AddLikeComment(int id);

        Task<IActionResult?> AddLikePost(int id);
        #endregion

        #region UPDATE
        Task<IActionResult?> UpdateUser(UserDto userDto);

        Task<IActionResult?> UpdatePostInterestOfPost(PostInterestDto postInterestDto);

        Task<IActionResult?> UpdateUserInterest(UserInterestDto userInterestDto);
        #endregion

        #region GET
        #region SPECIFIC
        Task<IActionResult?> GetUser(string nickname);

        Task<IActionResult?> GetPost(int id);

        Task<IActionResult?> GetComment(int id);

        Task<IActionResult?> GetPostInterestFromPostId(int id);

        Task<IActionResult?> GetUserInterestFromUserNickname(string nickname);
        #endregion

        #region GENERAL ALL
        Task<IActionResult?> GetAllUser();

        Task<IActionResult?> GetAllPost();

        Task<IActionResult?> GetAllComment();

        Task<IActionResult?> GetAllUserInterest();

        Task<IActionResult?> GetAllPostInterest();
        #endregion

        #region SPECIFIC ALL
        Task<IActionResult?> GetAllFollowerOfUser(string nickname);

        Task<IActionResult?> GetAllFollowingOfUser(string nickname);

        Task<IActionResult?> GetAllPostOfUser(string nickname);

        Task<IActionResult?> GetAllCommentOfPost(int id);
        #endregion
        #endregion

        #region REMOVE
        Task<IActionResult?> RemoveComment(int id);

        Task<IActionResult?> RemovePost(int id);

        Task<IActionResult?> RemovePostInterest(int id);

        Task<IActionResult?> RemoveUser(string nickname);

        Task<IActionResult?> RemoveUserInterest(string nickname);
        #endregion

    }
}

