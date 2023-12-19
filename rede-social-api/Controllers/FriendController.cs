using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rede_social_api.Services;
using rede_social_application.Commands.Friend.AcceptFriend;
using rede_social_application.Commands.Friend.GetFriend;
using rede_social_application.Commands.Friend.InviteFriend;
using rede_social_application.Commands.FriendList.ListFriend;
using rede_social_application.Models;

namespace rede_social_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FriendController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<List<FriendRequestModel>>> PendentInvite()
        {
            return await this._mediator.Send(new GetFriendRequestListRequest(HeaderService.DeserializedToken(Request)));
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<bool>> FriendRequestStatus()
        {
            var payload = await HeaderService.DeserializedPayload<FriendRequestStatusRequest>(Request);
            payload.Id = HeaderService.DeserializedToken(Request);
            return await this._mediator.Send(new FriendRequestStatusRequest(payload));
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<bool>> SendInvite()
        {
            var payload = await HeaderService.DeserializedPayload<InviteFriendRequest>(Request);
            var header = HeaderService.DeserializedToken(Request);
            return await this._mediator.Send(new InviteFriendRequest(header, payload.FriendUserName));
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<List<string>>> GetAllFriends()
        {
            var header = HeaderService.DeserializedToken(Request);
            return await this._mediator.Send(new ListFriendRequest(header));
        }
    }
}
