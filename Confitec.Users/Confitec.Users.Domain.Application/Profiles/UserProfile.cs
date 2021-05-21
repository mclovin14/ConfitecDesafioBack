using AutoMapper;
using Confitec.Users.Domain.Application.Commands.UpdateUser;
using Confitec.Users.Domain.Application.Commands.Users.AddUser;
using Confitec.Users.Domain.Core.Entities;

namespace Confitec.Users.Domain.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
