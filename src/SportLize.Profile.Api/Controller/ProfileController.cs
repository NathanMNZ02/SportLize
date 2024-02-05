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
}