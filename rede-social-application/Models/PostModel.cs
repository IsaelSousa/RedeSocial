namespace rede_social_application.Models
{
    public class PostModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string PostMessage { get; set; }
        public string Image { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
