using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.ListFriends
{
    public class ListFriendsHandler : IRequestHandler<ListFriendsRequest, Response<List<FriendListModel>>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IMapper mapper;

        public ListFriendsHandler(IFriendRepository friendRepository, IMapper mapper)
        {
            this.friendRepository = friendRepository;
            this.mapper = mapper;
        }

        public async Task<Response<List<FriendListModel>>> Handle(ListFriendsRequest request, CancellationToken cancellationToken)
        {
            var data = await friendRepository.GetAllFriends(request.Id);

            if (data == null) return new Response<List<FriendListModel>>(false);

            var response = this.mapper.Map<List<FriendListModel>>(data);

            return new Response<List<FriendListModel>>(response);

        }
    }
}
