using System;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Repository.Model;
using SportLize.Profile.Api.Profile.Shared.Dto;

namespace SportLize.Profile.Api.Profile.Repository.Abstraction
{
	public interface IRepository 
	{
        Task<int> SaveChanges(CancellationToken cancellationToken = default);

        #region INSERT
        Task<User> InsertUser(UserWriteDto userWriteDto, CancellationToken cancellationToken = default);
        Task<Post> InsertPost(PostWriteDto postWriteDto, CancellationToken cancellationToken = default);
        Task<Comment> InsertComment(CommentWriteDto commentWriteDto, CancellationToken cancellationToken = default);
        #endregion

        #region UPDATE
        Task<User> UpdateUser(UserReadDto oldUser, UserWriteDto newUser, CancellationToken cancellationToken = default);
        Task<Post> UpdatePost(PostReadDto oldPost, PostWriteDto newPost, CancellationToken cancellationToken = default);
        Task<Comment> UpdateComment(CommentReadDto oldComment, CommentWriteDto newComment, CancellationToken cancellationToken = default);
        #endregion

        #region GET
        Task<List<User>?> GetAllUser(CancellationToken cancellationToken = default);
        Task<List<Post>?> GetAllPostOfUser(UserReadDto userReadDto, CancellationToken cancellationToken = default);
        Task<List<Comment>?> GetAllComment(PostReadDto postReadDto, CancellationToken cancellationToken = default);
        Task<User?> GetUser(int id, CancellationToken cancellationToken = default);
        Task<Post?> GetPost(int id, CancellationToken cancellationToken = default);
        Task<Comment?> GetComment(int id, CancellationToken cancellationToken = default);
        #endregion

        #region DELETE
        Task<User> DeleteUser(UserReadDto userReadDto, CancellationToken cancellationToken = default);
        Task<Post> DeletePost(PostReadDto postReadDto, CancellationToken cancellationToken = default);
        Task<Comment> DeleteComment(CommentReadDto commentReadDto, CancellationToken cancellationToken = default);
        #endregion

        #region TRANSACTIONALOUTBOX
        Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default);
        Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);
        Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);
        Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default); 
        #endregion
    }
}

