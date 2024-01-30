using rede_social_domain.Models.Standard;

namespace rede_social_domain.Models.EFModels
{
    public class PostEF : StandardModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PostMessage { get; set; }
        public string FirstName { get; set; }
        public string Image { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public List<PostComments> PostComments { get; set; }
        public List<PostLikes> PostLikes { get; set; }
    }
}
