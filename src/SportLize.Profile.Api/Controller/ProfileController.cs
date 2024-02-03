using Microsoft.AspNetCore.Mvc;
using SportLize.Profile.Api.Profile.Business.Abstraction;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Repository.Model;
using SportLize.Profile.Api.Profile.Shared;

[ApiController]
[Route("[controller]/[action]")]
public class ProfileController : ControllerBase
{
    private readonly ILogger<ProfileController> _logger;
    private readonly IBusiness _business;

    public ProfileController(IBusiness business, ILogger<ProfileController> logger)
    {
        _business = business;
        _logger = logger;
    }

    #region CREATE
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto userDto)
    {
        try
        {
            await _business.CreateUser(userDto);
            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating user: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(CommentDto commentDto)
    {
        try
        {
            await _business.CreateComment(commentDto);
            return Ok("Comment created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating comment: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(PostDto postDto)
    {
        try
        {
            await _business.CreatePost(postDto);
            return Ok("Post created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating post: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePostInterest(PostInterestDto postInterestDto)
    {
        try
        {
            await _business.CreatePostInterest(postInterestDto);
            return Ok("Post interest created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating post interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserInterest(UserInterestDto userInterestDto)
    {
        try
        {
            await _business.CreateUserInterest(userInterestDto);
            return Ok("User interest created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating user interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
    #endregion

    #region ADD
    [HttpPost]
    public async Task<IActionResult> AddFollower(string nicknameUser, string nicknameFollower)
    {
        try
        {
            await _business.AddFollower(nicknameUser, nicknameFollower);
            return Ok($"Follower {nicknameFollower} added to user {nicknameUser} successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding follower to user: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddFollowing(string nicknameUser, string nicknameFollowing)
    {
        try
        {
            await _business.AddFollowing(nicknameUser, nicknameFollowing);
            return Ok($"Following {nicknameFollowing} added to user {nicknameUser} successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding follower to user: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddLikeComment(int id)
    {
        try
        {
            await _business.AddLikeComment(id);
            return Ok("Like added to comment successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding like to comment: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddLikePost(int id)
    {
        try
        {
            await _business.AddLikePost(id);
            return Ok("Like added to post successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding like to post: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
    #endregion

    #region UPDATE
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserDto userDto)
    {
        try
        {
            await _business.UpdateUser(userDto);
            return Ok("Post interest updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error updating post interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePostInterestOfPost(PostInterestDto postInterestDto)
    {
        try
        {
            await _business.UpdatePostInterestOfPost(postInterestDto);
            return Ok("Post interest updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error updating post interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserInterest(UserInterestDto userInterestDto)
    {
        try
        {
            await _business.UpdateUserInterest(userInterestDto);
            return Ok("Post interest updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error updating post interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
    #endregion

    #region GET
    #region SPECIFIC
    [HttpGet("{nickname}")]
    public async Task<IActionResult> GetUser(string nickname)
    {
        try
        {
            var user = await _business.GetUser(nickname);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting user: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(int id)
    {
        try
        {
            var post = await _business.GetPost(id);
            return Ok(post);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting post: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        try
        {
            var comment = await _business.GetComment(id);
            return Ok(comment);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting comment: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostInterestFromPostId(int id)
    {
        try
        {
            var postInterest = await _business.GetPostInterestFromPostId(id);
            return Ok(postInterest);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting post interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{nickname}")]
    public async Task<IActionResult> GetUserInterestFromUserNickname(string nickname)
    {
        try
        {
            var userInterest = await _business.GetUserInterestFromUserNickname(nickname);
            return Ok(userInterest);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting user interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
    #endregion

    #region GENERAL FOR ALL
    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        try
        {
            return Ok(await _business.GetAllUser());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all user: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPost()
    {
        try
        {
            return Ok(await _business.GetAllPost());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all post: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComment()
    {
        try
        {
            return Ok(await _business.GetAllComment());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all comment: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserInterest()
    {
        try
        {
            return Ok(await _business.GetAllUserInterest());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all user interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostInterest()
    {
        try
        {
            return Ok(await _business.GetAllPostInterest());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all post interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
    #endregion

    #region SPECIFIC FOR ALL
    [HttpGet("{Nickname}")]
    public async Task<IActionResult> GetAllFollowerOfUser(string nickname)
    {
        try
        {
            return Ok(await _business.GetAllFollowerOfUser(nickname));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all follower of user {nickname}: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{Nickname}")]
    public async Task<IActionResult> GetAllFollowingOfUser(string nickname)
    {
        try
        {
            return Ok(await _business.GetAllFollowingOfUser(nickname));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all following of user {nickname}: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{Nickname}")]
    public async Task<IActionResult> GetAllPostOfUser(string nickname)
    {
        try
        {
            return Ok(await _business.GetAllPostOfUser(nickname));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all post of user {nickname}: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllCommentOfPost(int id)
    {
        try
        {
            return Ok(await _business.GetAllCommentOfPost(id));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting all comment of post {id}: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
    #endregion

    #endregion

    #region REMOVE
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveComment(int id)
    {
        try
        {
            await _business.RemoveComment(id);
            return Ok("Comment removed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error removing comment: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePost(int id)
    {
        try
        {
            await _business.RemovePost(id);
            return Ok("Post removed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error removing post: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePostInterest(int id)
    {
        try
        {
            await _business.RemovePostInterest(id);
            return Ok("Post interest removed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error removing post interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{nickname}")]
    public async Task<IActionResult> RemoveUser(string nickname)
    {
        try
        {
            await _business.RemoveUser(nickname);
            return Ok("User removed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error removing user: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{nickname}")]
    public async Task<IActionResult> RemoveUserInterest(string nickname)
    {
        try
        {
            await _business.RemoveUserInterest(nickname);
            return Ok("User interest removed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error removing user interest: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
    #endregion
}