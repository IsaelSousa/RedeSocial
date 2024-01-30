using rede_social_domain.Models.Standard;

namespace rede_social_domain.Models.EFModels
{
    public class PostLikes : StandardModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostEF PostEF { get; set; }
    }
}
