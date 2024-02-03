using System;
using System.Collections;
using SportLize.Profile.Api.Profile.Business.Abstraction;
using SportLize.Profile.Api.Profile.Repository;
using SportLize.Profile.Api.Profile.Repository.Abstraction;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Repository.Model;
using SportLize.Profile.Api.Profile.Shared;

namespace SportLize.Profile.Api.Profile.Business
{
    public class Business : IBusiness
    {
        private readonly IRepository _repository;

        public Business(IRepository repository)
        {
            _repository = repository;
        }

        #region CREATE
        public async Task CreateUser(UserDto userDto)
        {
            await _repository.CreateUser(userDto.Actor, userDto.Nickname, userDto.Name, userDto.Surname, userDto.Password, userDto.Description, userDto.DateOfBorn);
        }

        public async Task CreateComment(CommentDto commentDto)
        {
            var post = await _repository.GetPost(commentDto.PostId);
            if (post is null)
                throw new Exception($"Not exist post with Id: {commentDto.PostId}");

            await _repository.CreateComment(commentDto.Text, commentDto.PubblicationDate, post);
        }

        public async Task CreatePost(PostDto postDto)
        {
            var user = await _repository.GetUser(postDto.UserId);
            if(user is null)
                throw new Exception($"Not exist user with id: {postDto.UserId}");

            await _repository.CreatePost(postDto.MediaBase64, postDto.PubblicationDate, postDto.Description, user);
        }

        public async Task CreatePostInterest(PostInterestDto postInterestDto)
        {
            var post = await _repository.GetPost(postInterestDto.PostId);
            if (post is null)
                throw new Exception($"Not exist post with Id: {postInterestDto.PostId}");

            await _repository.CreatePostInterest(
                postInterestDto.BodyBuilding,
                postInterestDto.PowerLifting,
                postInterestDto.CrossFit,
                postInterestDto.Calisthenics,
                postInterestDto.Swimming,
                postInterestDto.Surfing,
                postInterestDto.Kayaking,
                postInterestDto.Snorkeling,
                postInterestDto.Skiing,
                postInterestDto.Snowboarding,
                postInterestDto.IceSkating,
                postInterestDto.Yoga,
                postInterestDto.Pilates,
                postInterestDto.Running,
                postInterestDto.Cycling,
                postInterestDto.MartialArts,
                postInterestDto.RockClimbing,
                post);

        }

        public async Task CreateUserInterest(UserInterestDto userInterestDto)
        {
            var user = await _repository.GetUser(userInterestDto.UserId);
            if (user is null)
                throw new Exception($"Not exist user with nickname: {userInterestDto.UserId}");

            await _repository.CreateUserInterest(
                userInterestDto.BodyBuilding,
                userInterestDto.PowerLifting,
                userInterestDto.CrossFit,
                userInterestDto.Calisthenics,
                userInterestDto.Swimming,
                userInterestDto.Surfing,
                userInterestDto.Kayaking,
                userInterestDto.Snorkeling,
                userInterestDto.Skiing,
                userInterestDto.Snowboarding,
                userInterestDto.IceSkating,
                userInterestDto.Yoga,
                userInterestDto.Pilates,
                userInterestDto.Running,
                userInterestDto.Cycling,
                userInterestDto.MartialArts,
                userInterestDto.RockClimbing,
                user);
        }
        #endregion

        #region ADD
        public async Task AddFollower(string nicknameUser, string nicknameFollower)
        {
            await _repository.AddFollower(nicknameUser, nicknameFollower);
        }

        public async Task AddFollowing(string nicknameUser, string nicknameFollowing)
        {
            await _repository.AddFollowing(nicknameUser, nicknameFollowing);
        }

        public async Task AddLikeComment(int id)
        {
            await _repository.AddLikeComment(id);
        }

        public async Task AddLikePost(int id)
        {
            await _repository.AddLikePost(id);
        }
        #endregion

        #region UPDATE
        public async Task UpdateUser(UserDto userDto)
        {
            await _repository.UpdateUser(userDto.Nickname, userDto.Name, userDto.Surname, userDto.Password, userDto.Description, userDto.DateOfBorn);
        }

        public async Task UpdatePostInterestOfPost(PostInterestDto postInterestDto)
        {
            await _repository.UpdatePostInterestOfPost(
                postInterestDto.PostId,
                postInterestDto.BodyBuilding,
                postInterestDto.PowerLifting,
                postInterestDto.CrossFit,
                postInterestDto.Calisthenics,
                postInterestDto.Swimming,
                postInterestDto.Surfing,
                postInterestDto.Kayaking,
                postInterestDto.Snorkeling,
                postInterestDto.Skiing,
                postInterestDto.Snowboarding,
                postInterestDto.IceSkating,
                postInterestDto.Yoga,
                postInterestDto.Pilates,
                postInterestDto.Running,
                postInterestDto.Cycling,
                postInterestDto.MartialArts,
                postInterestDto.RockClimbing);
        }

        public async Task UpdateUserInterest(UserInterestDto userInterestDto)
        {
            await _repository.UpdateUserInterest(
                userInterestDto.UserId,
                userInterestDto.BodyBuilding,
                userInterestDto.PowerLifting,
                userInterestDto.CrossFit,
                userInterestDto.Calisthenics,
                userInterestDto.Swimming,
                userInterestDto.Surfing,
                userInterestDto.Kayaking,
                userInterestDto.Snorkeling,
                userInterestDto.Skiing,
                userInterestDto.Snowboarding,
                userInterestDto.IceSkating,
                userInterestDto.Yoga,
                userInterestDto.Pilates,
                userInterestDto.Running,
                userInterestDto.Cycling,
                userInterestDto.MartialArts,
                userInterestDto.RockClimbing);
        }

        #endregion

        #region GET
        #region SPECIFIC
        public async Task<UserDto?> GetUser(string nickname)
        {
            var user = await _repository.GetUser(nickname);
            if (user is null)
                return null;
            return MapUserToDto(user);
        }

        public async Task<PostDto?> GetPost(int id)
        {
            var post = await _repository.GetPost(id);
            if (post is null)
                return null;
            return MapPostToDto(post);
        }

        public async Task<CommentDto?> GetComment(int id)
        {
            var comment = await _repository.GetComment(id);
            if (comment is null)
                return null;
            return MapCommentToDto(comment);
        }

        public async Task<PostInterestDto?> GetPostInterestFromPostId(int id)
        {
            var postInterest = await _repository.GetPostInterestFromPostId(id);
            if (postInterest is null)
                return null;
            return MapPostInterestToDto(postInterest);
        }

        public async Task<UserInterestDto?> GetUserInterestFromUserNickname(string nickname)
        {
            var userInterest = await _repository.GetUserInterestFromUserNickname(nickname);
            if (userInterest is null)
                return null;
            return MapUserInterestToDto(userInterest);
        }
        #endregion

        #region GENERAL FOR ALL
        public async Task<IEnumerable<UserDto>?> GetAllUser()
        {
            var userList = await _repository.GetAllUser();
            if (userList is null)
                return null;

            var dtoUserList = new List<UserDto>();
            foreach (var user in userList)
            {
                dtoUserList.Add(MapUserToDto(user));
            }

            return dtoUserList;
        }

        public async Task<IEnumerable<PostDto>?> GetAllPost()
        {
            var postList = await _repository.GetAllPost();
            if (postList is null)
                return null;

            var dtoPostList = new List<PostDto>();
            foreach (var post in postList)
            {
                dtoPostList.Add(MapPostToDto(post));
            }

            return dtoPostList;
        }

        public async Task<IEnumerable<CommentDto>?> GetAllComment()
        {
            var commentList = await _repository.GetAllComment();
            if (commentList is null)
                return null;

            var dtoCommentList = new List<CommentDto>();
            foreach (var comment in commentList)
            {
                dtoCommentList.Add(MapCommentToDto(comment));
            }

            return dtoCommentList;
        }

        public async Task<IEnumerable<PostInterestDto>?> GetAllPostInterest()
        {
            var postInterestList = await _repository.GetAllPostInterest();
            if (postInterestList is null)
                return null;

            var dtoPostInterestList = new List<PostInterestDto>();
            foreach(var postInterest in postInterestList)
            {
                dtoPostInterestList.Add(MapPostInterestToDto(postInterest));
            }
            return dtoPostInterestList;
        }

        public async Task<IEnumerable<UserInterestDto>?> GetAllUserInterest()
        {
            var userInterestList = await _repository.GetAllUserInterest();
            if (userInterestList is null)
                return null;

            var dtoUserInterestList = new List<UserInterestDto>();
            foreach (var userInterest in userInterestList)
            {
                dtoUserInterestList.Add(MapUserInterestToDto(userInterest));
            }
            return dtoUserInterestList;
        }
        #endregion

        #region SPECIFIC FOR ALL
        public async Task<IEnumerable<UserDto>?> GetAllFollowerOfUser(string nickname)
        {
            var followerList = await _repository.GetAllFollowerOfUser(nickname);
            if (followerList is null)
                return null;

            var dtoFollowerList = new List<UserDto>();
            foreach (var follower in followerList)
            {
                dtoFollowerList.Add(MapUserToDto(follower));
            }
            return dtoFollowerList;
        }

        public async Task<IEnumerable<UserDto>?> GetAllFollowingOfUser(string nickname)
        {
            var followingList = await _repository.GetAllFollowingOfUser(nickname);
            if (followingList is null)
                return null;

            var dtoFollowingList = new List<UserDto>();
            foreach(var following in followingList)
            {
                dtoFollowingList.Add(MapUserToDto(following));
            }
            return dtoFollowingList;
        }

        public async Task<IEnumerable<PostDto>?> GetAllPostOfUser(string nickname)
        {
            var postList = await _repository.GetAllPostOfUser(nickname);
            if (postList is null)
                return null;

            var dtoPostList = new List<PostDto>();
            foreach (var post in postList)
            {
                dtoPostList.Add(MapPostToDto(post));
            }

            return dtoPostList;
        }

        public async Task<IEnumerable<CommentDto>?> GetAllCommentOfPost(int id)
        {
            var commentList = await _repository.GetAllCommentOfPost(id);
            if (commentList is null)
                return null;

            var dtoCommentList = new List<CommentDto>();
            foreach(var comment in commentList)
            {
                dtoCommentList.Add(MapCommentToDto(comment));
            }

            return dtoCommentList;
        }
        #endregion
        #endregion

        #region REMOVE
        public async Task RemoveUser(string nickname)
        {
            await _repository.RemoveUser(nickname);
        }

        public async Task RemovePost(int id)
        {
            await _repository.RemovePost(id);
        }

        public async Task RemoveComment(int id)
        {
            await _repository.RemoveComment(id);
        }

        public async Task RemovePostInterest(int id)
        {
            await _repository.RemovePostInterest(id);
        }

        public async Task RemoveUserInterest(string nickname)
        {
            await _repository.RemoveUserInterest(nickname);
        }
        #endregion

        #region MAPPING
        public static UserDto MapUserToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Actor = user.Actor,
                Nickname = user.Nickname,
                Name = user.Name,
                Surname = user.Surname,
                Password = user.Password,
                Description = user.Description,
                DateOfBorn = user.DateOfBorn
            };
        }

        public static PostDto MapPostToDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                MediaBase64 = Convert.ToBase64String(post.Media),
                Like = post.Like,
                PubblicationDate = post.PubblicationDate,
                UserId = post.UserId,
                Description = post.Description
            };
        }

        public static CommentDto MapCommentToDto(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Text = comment.Text,
                Like = comment.Like,
                PubblicationDate = comment.PubblicationDate,
                PostId = comment.PostId
            };
        }

        public static PostInterestDto MapPostInterestToDto(PostInterest postInterest)
        {
            return new PostInterestDto
            {
                Id = postInterest.Id,
                BodyBuilding = postInterest.BodyBuilding,
                PowerLifting = postInterest.PowerLifting,
                CrossFit = postInterest.CrossFit,
                Calisthenics = postInterest.Calisthenics,
                Swimming = postInterest.Swimming,
                Surfing = postInterest.Surfing,
                Kayaking = postInterest.Kayaking,
                Snorkeling = postInterest.Snorkeling,
                Skiing = postInterest.Skiing,
                Snowboarding = postInterest.Snowboarding,
                IceSkating = postInterest.IceSkating,
                Yoga = postInterest.Yoga,
                Pilates = postInterest.Pilates,
                Running = postInterest.Running,
                Cycling = postInterest.Cycling,
                MartialArts = postInterest.MartialArts,
                RockClimbing = postInterest.RockClimbing,
                PostId = postInterest.PostId
            };
        }

        public static UserInterestDto MapUserInterestToDto(UserInterest userInterest)
        {
            return new UserInterestDto
            {
                Id = userInterest.Id,
                BodyBuilding = userInterest.BodyBuilding,
                PowerLifting = userInterest.PowerLifting,
                CrossFit = userInterest.CrossFit,
                Calisthenics = userInterest.Calisthenics,
                Swimming = userInterest.Swimming,
                Surfing = userInterest.Surfing,
                Kayaking = userInterest.Kayaking,
                Snorkeling = userInterest.Snorkeling,
                Skiing = userInterest.Skiing,
                Snowboarding = userInterest.Snowboarding,
                IceSkating = userInterest.IceSkating,
                Yoga = userInterest.Yoga,
                Pilates = userInterest.Pilates,
                Running = userInterest.Running,
                Cycling = userInterest.Cycling,
                MartialArts = userInterest.MartialArts,
                RockClimbing = userInterest.RockClimbing,
                UserId = userInterest.UserId
            };
        }
        #endregion
    }
}

