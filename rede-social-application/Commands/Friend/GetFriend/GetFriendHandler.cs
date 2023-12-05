using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendAggregate;

namespace rede_social_application.Commands.Friend.GetFriend
{
    public class GetFriendHandler : IRequestHandler<GetFriendRequest, Response<List<FriendListModel>>>
    {
        private readonly IFriendRepository repository;
        private readonly IMapper mapper;

        public GetFriendHandler(IFriendRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Response<List<FriendListModel>>> Handle(GetFriendRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllFriends(request.UserId); 
        
            if (data == null) return new Response<List<FriendListModel>>(false).AddMessage("Empty friends list!");

            return new Response<List<FriendListModel>>(this.mapper.Map<List<FriendListModel>>(data));

        }
    }
}
