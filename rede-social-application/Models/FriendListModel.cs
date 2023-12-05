using rede_social_domain.Models.Standard;

namespace rede_social_application.Models
{
    public class FriendListModel : StandardModel
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
