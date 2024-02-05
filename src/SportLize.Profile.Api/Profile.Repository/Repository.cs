using SportLize.Profile.Api.Profile.Repository.Abstraction;
using SportLize.Profile.Api.Profile.Repository.Model;
using SportLize.Profile.Api.Profile.Shared.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SportLize.Profile.Api.Profile.Repository
{
    public class Repository : IRepository
    {
        private readonly IMapper _mapper;
        private readonly ProfileDbContext _profileDbContext;

        public Repository(ProfileDbContext profileDbContext, IMapper mapper)
        {
            _profileDbContext = profileDbContext;
            _mapper = mapper;
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default) =>
            await _profileDbContext.SaveChangesAsync(cancellationToken);

        #region INSERT
        public async Task<User> InsertUser(UserWriteDto userWriteDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userWriteDto);
            await _profileDbContext.User.AddAsync(user, cancellationToken);
            return user;
        }

        public async Task<Post> InsertPost(PostWriteDto postWriteDto, CancellationToken cancellationToken = default)
        {
            var post = _mapper.Map<Post>(postWriteDto);
            await _profileDbContext.Post.AddAsync(post, cancellationToken);
            return post;
        }

        public async Task<Comment> InsertComment(CommentWriteDto commentWriteDto, CancellationToken cancellationToken = default)
        {
            var comment = _mapper.Map<Comment>(commentWriteDto);
            await _profileDbContext.Comment.AddAsync(comment, cancellationToken);
            return comment;
        }
        #endregion

        #region UPDATE
        public async Task<User> UpdateUser(UserReadDto oldUserDto, UserWriteDto newUserDto, CancellationToken cancellationToken = default)
        {
            var user = await _profileDbContext.User.FirstOrDefaultAsync(s => s.Id == oldUserDto.Id, cancellationToken);

            if (user is not null)
                await DeleteUser(oldUserDto, cancellationToken);

            var newUser = _mapper.Map<User>(newUserDto);
            await _profileDbContext.User.AddAsync(newUser, cancellationToken);
            return newUser;
        }

        public async Task<Post> UpdatePost(PostReadDto oldPostDto, PostWriteDto newPostDto, CancellationToken cancellationToken = default)
        {
            var post = await _profileDbContext.Post.FirstOrDefaultAsync(s => s.Id == oldPostDto.Id, cancellationToken);

            if (post is not null)
                await DeletePost(oldPostDto, cancellationToken);

            var newPost = _mapper.Map<Post>(newPostDto);
            await _profileDbContext.Post.AddAsync(newPost, cancellationToken);
            return newPost;
        }

        public async Task<Comment> UpdateComment(CommentReadDto oldCommentDto, CommentWriteDto newCommentDto, CancellationToken cancellationToken = default)
        {
            var comment = await _profileDbContext.Comment.FirstOrDefaultAsync(s => s.Id == oldCommentDto.Id, cancellationToken);

            if (comment is not null)
                await DeleteComment(oldCommentDto, cancellationToken);

            var newComment = _mapper.Map<Comment>(newCommentDto);
            await _profileDbContext.Comment.AddAsync(newComment, cancellationToken);
            return newComment;
        }
        #endregion

        #region GET
        public async Task<List<User>?> GetAllUser(CancellationToken cancellationToken = default) =>
            await _profileDbContext.User.ToListAsync(cancellationToken);

        public async Task<List<Post>?> GetAllPostOfUser(UserReadDto userReadDto, CancellationToken cancellationToken = default)
        {
            var user = await GetUser(userReadDto.Id, cancellationToken);
            if (user is null)
                return null;
            return user.Posts;
        }

        public async Task<List<Comment>?> GetAllComment(PostReadDto postReadDto, CancellationToken cancellationToken = default)
        {
            var post = await GetPost(postReadDto.Id, cancellationToken);
            if (post is null)
                return null;
            return post.Comments;
        }

        public async Task<User?> GetUser(int id, CancellationToken cancellationToken = default) =>
            await _profileDbContext.User.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        public async Task<Post?> GetPost(int id, CancellationToken cancellationToken = default) =>
            await _profileDbContext.Post.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        public async Task<Comment?> GetComment(int id, CancellationToken cancellationToken = default) =>
            await _profileDbContext.Comment.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        #endregion

        #region DELETE
        public async Task<User> DeleteUser(UserReadDto userReadDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userReadDto);
            _profileDbContext.User.Remove(user);
            return user;
        }

        public async Task<Post> DeletePost(PostReadDto postReadDto, CancellationToken cancellationToken = default)
        {
            var post = _mapper.Map<Post>(postReadDto);
            _profileDbContext.Post.Remove(post);
            return post;
        }

        public async Task<Comment> DeleteComment(CommentReadDto commentReadDto, CancellationToken cancellationToken = default)
        {
            var comment = _mapper.Map<Comment>(commentReadDto);
            _profileDbContext.Comment.Remove(comment);
            return comment;
        }
        #endregion

        #region TRANSACTIONAL OUTBOX
        public async Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default) => 
            await _profileDbContext.TransactionalOutboxes.ToListAsync(cancellationToken);

        public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default) =>
            await _profileDbContext.TransactionalOutboxes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default) =>
            _profileDbContext.TransactionalOutboxes.Remove((await GetTransactionalOutboxByKey(id, cancellationToken)) ?? throw new ArgumentException($"TransactionalOutbox con id {id} non trovato", nameof(id)));

        public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default) =>
            await _profileDbContext.TransactionalOutboxes.AddAsync(transactionalOutbox);
        #endregion
    }
}