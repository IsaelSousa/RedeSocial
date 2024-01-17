using AutoMapper;
using rede_social_application.Models;
using rede_social_domain.Models.EFModels;

namespace rede_social_application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostEF, PostModel>()
                .ReverseMap();

            CreateMap<FriendRequestEF, FriendRequestModel>()
                .ReverseMap();

            CreateMap<FriendRequestList, FriendRequestListModel>()
                .ReverseMap();

            CreateMap<FriendListEF, FriendListModel>()
                .ReverseMap();
        }
    }
}
