using rede_social_domain.Models.Standard;

namespace rede_social_application.Models
{
    public class FriendListModel : StandardModel
    {

        public FriendListModel(string userId, string friendId)
        {
            this.UserId = userId;
            this.FriendId = friendId;
        }

        public string UserId { get; set; }
        public string FriendId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
