using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportLize.Profile.Api.Profile.ClientHttp.Abstraction;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Shared;

namespace SportLize.Profile.Api.Profile.ClientHttp
{
	public class ClientHttp : IClientHttp
	{
		private readonly HttpClient _httpClient;

		public ClientHttp(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

        #region CREATE
        public async Task<IActionResult?> CreateUser(UserDto userDto)
        {
            var respose = await _httpClient.PostAsync("Profile/CreateUser", JsonContent.Create(userDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> CreateComment(CommentDto commentDto)
        {
            var respose = await _httpClient.PostAsync("Profile/CreateComment", JsonContent.Create(commentDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> CreatePost(PostDto postDto)
        {
            var respose = await _httpClient.PostAsync("Profile/CreatePost", JsonContent.Create(postDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> CreatePostInterest(PostInterestDto postInterestDto)
        {
            var respose = await _httpClient.PostAsync("Profile/CreatePostInterest", JsonContent.Create(postInterestDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> CreateUserInterest(UserInterestDto userInterestDto)
        {
            var respose = await _httpClient.PostAsync("Profile/CreateUserInterest", JsonContent.Create(userInterestDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }
        #endregion

        #region ADD
        public async Task<IActionResult?> AddFollower(string nicknameUser, string nicknameFollower)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "nicknameUser", nicknameUser },
                { "nicknameFollower", nicknameFollower }
            });

            var respose = await _httpClient.GetAsync($"/Profile/AddFollower{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> AddFollowing(string nicknameUser, string nicknameFollowing)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "nicknameUser", nicknameUser },
                { "nicknameFollowing", nicknameFollowing }
            });

            var respose = await _httpClient.GetAsync($"/Profile/AddFollowing{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> AddLikeComment(int id)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "id", id.ToString(CultureInfo.InvariantCulture) },
            });

            var respose = await _httpClient.GetAsync($"/Profile/AddLikeComment{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> AddLikePost(int id)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "id", id.ToString(CultureInfo.InvariantCulture) },
            });

            var respose = await _httpClient.GetAsync($"/Profile/AddLikePost{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }
        #endregion

        #region UPDATE
        public async Task<IActionResult?> UpdateUser(UserDto userDto)
        {
            var respose = await _httpClient.PostAsync("Profile/UpdateUser", JsonContent.Create(userDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> UpdatePostInterestOfPost(PostInterestDto postInterestDto)
        {
            var respose = await _httpClient.PostAsync("Profile/UpdatePostInterestOfPost", JsonContent.Create(postInterestDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> UpdateUserInterest(UserInterestDto userInterestDto)
        {
            var respose = await _httpClient.PostAsync("Profile/UpdateUserInterest", JsonContent.Create(userInterestDto));
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }
        #endregion

        #region GET
        #region SPECIFIC
        public async Task<IActionResult?> GetUser(string nickname)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "nickname", nickname }
            });

            var respose = await _httpClient.GetAsync($"/Profile/GetUser{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetPost(int id)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "id", id.ToString(CultureInfo.InvariantCulture) }
            });

            var respose = await _httpClient.GetAsync($"/Profile/GetPost{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetComment(int id)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "id", id.ToString(CultureInfo.InvariantCulture) }
            });

            var respose = await _httpClient.GetAsync($"/Profile/GetComment{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetPostInterestFromPostId(int id)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "id", id.ToString(CultureInfo.InvariantCulture) }
            });

            var respose = await _httpClient.GetAsync($"/Profile/GetPostInterestFromPostId{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetUserInterestFromUserNickname(string nickname)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "nickname", nickname }
            });

            var respose = await _httpClient.GetAsync($"/Profile/GetUserInterestFromUserNickname{queryString}");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }
        #endregion

        #region GENERAL
        public async Task<IActionResult?> GetAllUser()
        {
            var respose = await _httpClient.GetAsync($"/Profile/GetAllUser");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetAllPost()
        {
            var respose = await _httpClient.GetAsync($"/Profile/GetAllPost");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetAllComment()
        {
            var respose = await _httpClient.GetAsync($"/Profile/GetAllComment");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetAllUserInterest()
        {
            var respose = await _httpClient.GetAsync($"/Profile/GetAllUserInterest");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }

        public async Task<IActionResult?> GetAllPostInterest()
        {
            var respose = await _httpClient.GetAsync($"/Profile/GetAllPostInterest");
            return await respose.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>();
        }
        #endregion

        //TO DO
        public async Task<IActionResult> GetAllFollowerOfUser(string nickname)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllFollowingOfUser(string nickname)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllPostOfUser(string nickname)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllCommentOfPost(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region REMOVE
        public async Task<IActionResult> RemoveComment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> RemovePost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> RemovePostInterest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> RemoveUser(string nickname)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> RemoveUserInterest(string nickname)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

