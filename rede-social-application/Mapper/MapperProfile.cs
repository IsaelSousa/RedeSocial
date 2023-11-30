using AutoMapper;
using rede_social_application.Models;
using rede_social_domain.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostEF, PostModel>()
                .ReverseMap();

            CreateMap<FriendsEF, FriendsModel>()
                .ReverseMap();

            CreateMap<FriendsEF, FriendsListModel>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.FriendUserName))
                .ReverseMap();
        }
    }
}
