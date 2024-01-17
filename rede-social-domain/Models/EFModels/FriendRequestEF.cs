using rede_social_domain.Models.Standard;

namespace rede_social_domain.Models.EFModels
{
    public class FriendRequestEF : StandardModel
    {
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public char Status { get; set; }

        public FriendRequestEF(string FromUserId, string ToUserId)
        {
            this.FromUserId = FromUserId;
            this.ToUserId = ToUserId;
        }

    }
}
