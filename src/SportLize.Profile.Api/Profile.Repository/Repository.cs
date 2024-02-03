using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SportLize.Profile.Api.Profile.Repository.Abstraction;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Repository.Model;
using static System.Net.Mime.MediaTypeNames;

namespace SportLize.Profile.Api.Profile.Repository
{
    public class Repository : IRepository
    {
        private readonly ProfileDbContext _profileDbContext;

        public Repository(ProfileDbContext profileDbContext)
        {
            _profileDbContext = profileDbContext;
        }

        public async Task<int> SaveChanges()
        {
            return await _profileDbContext.SaveChangesAsync();
        }

        #region CREATE
        /// <summary>
        /// Le eccezioni vengono invocate nel momento in cui un parametro Dto che è in relazione con un altro non esiste oppure quando
        /// si prova a creare un user con un nickname già esistente
        /// </summary>
        /// <exception cref="Exception"></exception>
        
        public async Task CreateUser(Actor actor, string nickname, string name, string surname, string password, string description, DateTime dateOfBorn)
        {
  
                if (await GetUser(nickname) is not null)
                    throw new Exception($"User with nickname:{nickname} already exist");

                var user = new User()
                {
                    Actor = actor,
                    Nickname = nickname,
                    Name = name,
                    Surname = surname,
                    Password = password,
                    Description = description,
                    DateOfBorn = dateOfBorn.ToUniversalTime()
                };

                await _profileDbContext.User.AddAsync(user);
                await SaveChanges();
        }

        public async Task CreateComment(string text, DateTime pubblicationDate, Post post)
        {
            var comment = new Comment()
            {
                Text = text,
                Like = 0,
                PubblicationDate = pubblicationDate.ToUniversalTime(),
                Post = post,
                PostId = post.Id
            };

            await _profileDbContext.Comment.AddAsync(comment);
            await SaveChanges();
        }

        public async Task CreatePost(string mediaBase64, DateTime pubblicationDate, string? description, User user)
        {
            var post = new Post()
            {
                Media = Convert.FromBase64String(mediaBase64),
                Like = 0,
                PubblicationDate = pubblicationDate.ToUniversalTime(),
                Description = description,
                User = user,
                UserId = user.Id
            };

            await _profileDbContext.Post.AddAsync(post);
            await SaveChanges();
        }

        public async Task CreatePostInterest(bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing, Post post)
        {
            var postInterest = new PostInterest()
            {
                BodyBuilding = bodyBuilding,
                PowerLifting = powerLifting,
                CrossFit = crossFit,
                Calisthenics = calisthenics,
                Swimming = swimming,
                Surfing = surfing,
                Kayaking = kayaking,
                Snorkeling = snorkleing,
                Skiing = skiing,
                Snowboarding = snowboarding,
                IceSkating = iceSkating,
                Yoga = yoga,
                Pilates = pilates,
                Running = running,
                Cycling = cycling,
                MartialArts = martialArts,
                RockClimbing = rockClimbing,
                Post = post,
                PostId = post.Id
            };

            await _profileDbContext.PostInterest.AddAsync(postInterest);
            await SaveChanges();
        }

        public async Task CreateUserInterest(bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing, User user)
        {
            var userInterest = new UserInterest()
            {
                BodyBuilding = bodyBuilding,
                PowerLifting = powerLifting,
                CrossFit = crossFit,
                Calisthenics = calisthenics,
                Swimming = swimming,
                Surfing = surfing,
                Kayaking = kayaking,
                Snorkeling = snorkleing,
                Skiing = skiing,
                Snowboarding = snowboarding,
                IceSkating = iceSkating,
                Yoga = yoga,
                Pilates = pilates,
                Running = running,
                Cycling = cycling,
                MartialArts = martialArts,
                RockClimbing = rockClimbing,
                User = user,
                UserId = user.Id
            };

            await _profileDbContext.UserInterest.AddAsync(userInterest);
            await SaveChanges();
        }
        #endregion

        #region ADD
        public async Task AddFollower(string nicknameUser, string nicknameFollower)
        {
            var user = await this.GetUser(nicknameUser);
            var follower = await this.GetUser(nicknameFollower);

            if (user is null)
                throw new Exception("User is null");

            if (follower is null)
                throw new Exception("Follower is null");

            if (user.Followers.Contains(follower) == true)
                user.Followers.Add(follower);

            if (follower.Following.Contains(user) == false)
                follower.Following.Add(user);

            await SaveChanges();
        }

        public async Task AddFollowing(string nicknameUser, string nicknameFollowing)
        {
            var user = await this.GetUser(nicknameUser);
            var following = await this.GetUser(nicknameFollowing);
            if (user is null)
                throw new Exception("User is null");

            if (following is null)
                throw new Exception("Follower is null");

            if (user.Following.Contains(following) == true)
                throw new Exception($"User: {nicknameUser} already follow user: {nicknameFollowing}");

            user.Following.Add(following);

            /*Aggiungo che user è un nuovo follower di following*/

            if (following.Followers.Contains(user) == false)
                following.Followers.Add(user);

            await SaveChanges();
        }

        public async Task AddLikeComment(int id)
        {
            var comment = await GetComment(id);
            if (comment is null)
                throw new Exception("Comment not exist");

            comment.Like = comment.Like + 1;

            await SaveChanges();
        }

        public async Task AddLikePost(int id)
        {
            var post = await GetPost(id);
            if (post is null)
                throw new Exception("Post not exist");

            post.Like = post.Like + 1;

            await SaveChanges();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Le eccezioni sono dovute al fatto che una chiamata update deve essere fatta su un oggetto esistente, se l'oggetto
        /// non esiste c'è un problema
        /// </summary>
        /// <exception cref="Exception"></exception>

        public async Task UpdateUser(string nickname, string name, string surname, string password, string description, DateTime dateOfBorn)
        {
            var user = await GetUser(nickname);
            if (user is null)
                throw new Exception("User is null");

            user.Name = name;
            user.Surname = surname;
            user.Password = password;
            user.Description = description;
            user.DateOfBorn = dateOfBorn.ToUniversalTime();

            await SaveChanges();
        }

        public async Task UpdatePostInterestOfPost(int id, bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing)
        {
            var postInterest = await GetPostInterestFromPostId(id);
            if (postInterest is null)
                throw new Exception("PostInterest is null");

            postInterest.BodyBuilding = bodyBuilding;
            postInterest.PowerLifting = powerLifting;
            postInterest.CrossFit = crossFit;
            postInterest.Calisthenics = calisthenics;
            postInterest.Swimming = swimming;
            postInterest.Surfing = surfing;
            postInterest.Kayaking = kayaking;
            postInterest.Snorkeling = snorkleing;
            postInterest.Skiing = skiing;
            postInterest.Snowboarding = snowboarding;
            postInterest.IceSkating = iceSkating;
            postInterest.Yoga = yoga;
            postInterest.Pilates = pilates;
            postInterest.Running = running;
            postInterest.Cycling = cycling;
            postInterest.MartialArts = martialArts;
            postInterest.RockClimbing = rockClimbing;

            await SaveChanges();
        }

        public async Task UpdateUserInterest(int id, bool bodyBuilding, bool powerLifting, bool crossFit, bool calisthenics, bool swimming, bool surfing, bool kayaking, bool snorkleing, bool skiing, bool snowboarding, bool iceSkating, bool yoga, bool pilates, bool running, bool cycling, bool martialArts, bool rockClimbing)
        {
            var userInterest = await GetUserInterestFromUserId(id);
            if (userInterest is null)
                throw new Exception("UserInterest is null");

            userInterest.BodyBuilding = bodyBuilding;
            userInterest.PowerLifting = powerLifting;
            userInterest.CrossFit = crossFit;
            userInterest.Calisthenics = calisthenics;
            userInterest.Swimming = swimming;
            userInterest.Surfing = surfing;
            userInterest.Kayaking = kayaking;
            userInterest.Snorkeling = snorkleing;
            userInterest.Skiing = skiing;
            userInterest.Snowboarding = snowboarding;
            userInterest.IceSkating = iceSkating;
            userInterest.Yoga = yoga;
            userInterest.Pilates = pilates;
            userInterest.Running = running;
            userInterest.Cycling = cycling;
            userInterest.MartialArts = martialArts;
            userInterest.RockClimbing = rockClimbing;

            await SaveChanges();
        }
        #endregion

        #region GET
        #region SPECIFIC
        public async Task<User?> GetUser(string nickname)
        {
            return await _profileDbContext.User.Where(s => s.Nickname == nickname).SingleOrDefaultAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _profileDbContext.User.Where(s => s.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Post?> GetPost(int id)
        {
            return await _profileDbContext.Post.Where(s => s.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Comment?> GetComment(int id)
        {
            return await _profileDbContext.Comment.Where(s => s.Id == id).SingleOrDefaultAsync();
        }

        public async Task<PostInterest?> GetPostInterestFromPostId(int id)
        {
            var post = await _profileDbContext.Post.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (post is null)
                return null;

            return post.PostInterest;
        }

        public async Task<UserInterest?> GetUserInterestFromUserNickname(string nickname)
        {
            var user = await _profileDbContext.User.Where(s => s.Nickname == nickname).SingleOrDefaultAsync();
            if (user is null)
                return null;

            return user.UserInterest;
        }

        public async Task<UserInterest?> GetUserInterestFromUserId(int id)
        {
            var user = await _profileDbContext.User.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (user is null)
                return null;

            return user.UserInterest;
        }
        #endregion

        #region GENERAL FOR ALL
        public async Task<IEnumerable<User>?> GetAllUser()
        {
            return await _profileDbContext.User.ToListAsync();
        }

        public async Task<IEnumerable<Post>?> GetAllPost()
        {
            return await _profileDbContext.Post.ToListAsync();
        }

        public async Task<IEnumerable<Comment>?> GetAllComment()
        {
            return await _profileDbContext.Comment.ToListAsync();
        }

        public async Task<IEnumerable<UserInterest>?> GetAllUserInterest()
        {
            return await _profileDbContext.UserInterest.ToListAsync();
        }

        public async Task<IEnumerable<PostInterest>?> GetAllPostInterest()
        {
            return await _profileDbContext.PostInterest.ToListAsync();
        }
        #endregion

        #region SPECIFIC FOR ALL
        public async Task<IEnumerable<User>?> GetAllFollowerOfUser(string nickname)
        {
            var user = await _profileDbContext.User.Where(x => x.Nickname == nickname).SingleOrDefaultAsync();
            if (user is null)
                return null;

            return user.Followers;
        }

        public async Task<IEnumerable<User>?> GetAllFollowingOfUser(string nickname)
        {
            var user = await _profileDbContext.User.Where(x => x.Nickname == nickname).SingleOrDefaultAsync();
            if (user is null)
                return null;

            return user.Following;
        }

        public async Task<IEnumerable<Post>?> GetAllPostOfUser(string nickname)
        {
            var user = await _profileDbContext.User.Where(x => x.Nickname == nickname).SingleOrDefaultAsync();
            if (user is null)
                return null;

            return user.Posts;
        }

        public async Task<IEnumerable<Comment>?> GetAllCommentOfPost(int id)
        {
            var post = await _profileDbContext.Post.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (post is null)
                return null;

            return post.Comments;
        }
        #endregion
        #endregion

        #region REMOVE
        /// <summary>
        /// Le eccezioni sono dovute al fatto che una chiamata remove deve essere fatta su un oggetto esistente, se l'oggetto
        /// non esiste c'è un problema
        /// </summary>
        /// <exception cref="Exception"></exception>

        public async Task RemoveUser(string nickname)
        {
            var user = await GetUser(nickname);
            if (user is null)
                throw new Exception("User not exist");

            _profileDbContext.User.Remove(user);
            await SaveChanges();
        }

        public async Task RemovePost(int id)
        {
            var post = await GetPost(id);
            if (post is null)
                throw new Exception("Post not exist");

            _profileDbContext.Post.Remove(post);
            await SaveChanges();
        }

        public async Task RemoveComment(int id)
        {
            var comment = await GetComment(id);
            if (comment is null)
                throw new Exception("Comment not exist");

            _profileDbContext.Comment.Remove(comment);
            await SaveChanges();
        }

        public async Task RemovePostInterest(int id)
        {
            var postInterest = await GetPostInterestFromPostId(id);
            if (postInterest is null)
                throw new Exception("PostInterest not exist");

            _profileDbContext.PostInterest.Remove(postInterest);
            await SaveChanges();
        }

        public async Task RemoveUserInterest(string nickname)
        {
            var userInterest = await GetUserInterestFromUserNickname(nickname);
            if (userInterest is null)
                throw new Exception("UserInterest not exist");

            _profileDbContext.UserInterest.Remove(userInterest);
            await SaveChanges();
        }
        #endregion
    }
}