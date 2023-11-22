using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.GetRequestInvite
{
    public class GetRequestInviteHandler : IRequestHandler<GetRequestInviteRequest, Response<List<RequestInviteModel>>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IMapper mapper;
        public GetRequestInviteHandler(IFriendRepository friendRepository, IMapper mapper) 
        {
            this.friendRepository = friendRepository;
            this.mapper = mapper;
        }

        public async Task<Response<List<RequestInviteModel>>> Handle(GetRequestInviteRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendRepository.VerifyExistsInviteUser(request.Id);

            if (data == null) return null;

            var resp = this.mapper.Map<List<RequestInviteModel>>(data);

            return new Response<List<RequestInviteModel>>(resp, true); 
        }
    }
}
