using rede_social_domain.Models.Standard;

namespace rede_social_application.Models
{
    public class FriendRequestModel : StandardModel
    {
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public char Status { get; set; }
    }
}
