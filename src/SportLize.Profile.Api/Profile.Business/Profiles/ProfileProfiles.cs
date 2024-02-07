using AutoMapper;
using SportLize.Profile.Api.Profile.Repository.Model;
using SportLize.Profile.Api.Profile.Shared.Dto;

namespace SportLize.Profile.Api.Profile.Business.Profiles
{
    public sealed class AssemblyMarker
    {
        AssemblyMarker() { }
    }

    public class InputFileProfile : AutoMapper.Profile
    {
        public InputFileProfile() 
        {
            CreateMap<UserWriteDto, User>();
            CreateMap<User, UserWriteDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<User, UserReadDto>();

            CreateMap<CommentWriteDto, Comment>();
            CreateMap<Comment, CommentWriteDto>();
            CreateMap<CommentReadDto, Comment>();
            CreateMap<Comment, CommentReadDto>();

            CreateMap<PostWriteDto, Post>();
            CreateMap<Post, PostWriteDto>();
            CreateMap<PostReadDto, Post>();
            CreateMap<Post, PostReadDto>();
        }
    }
}
