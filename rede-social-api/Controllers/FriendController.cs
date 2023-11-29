using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rede_social_application.Commands.Friend.AcceptFriend;
using rede_social_application.Commands.Friend.GetRequestInvite;
using rede_social_application.Commands.Friend.InviteFriend;
using rede_social_application.Commands.Post.InsertPost;
using rede_social_application.Models;
using rede_social_application.Services;
using System.Text;

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
        public async Task<Response<List<FriendsListModel>>> PendentInvite()
        {
            var body = String.Empty;
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            Dictionary<string, string> deserializedToken = Token.Deserialize(token);

            GetRequestInviteRequest data = new GetRequestInviteRequest();
            data.Id = deserializedToken["Id"];
            return await this._mediator.Send(data);
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<bool>> AcceptInvite()
        {
            var body = String.Empty;
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            Dictionary<string, string> deserializedToken = Token.Deserialize(token);

            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                body = await reader.ReadToEndAsync();

            AcceptFriendRequest data = EncryptionHelper.DecryptData<AcceptFriendRequest>(body);
            data.Id = deserializedToken["Id"];
            return await this._mediator.Send(data);
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<bool>> Invite()
        {
            var body = String.Empty;
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            Dictionary<string, string> deserializedToken = Token.Deserialize(token);

            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                body = await reader.ReadToEndAsync();

            InviteFriendRequest data = EncryptionHelper.DecryptData<InviteFriendRequest>(body);
            data.UserId = deserializedToken["Id"];
            return await this._mediator.Send(data);
        }

        [HttpGet("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<List<FriendsListModel>>> GetAllFriends()
        {

        }
    }
}
