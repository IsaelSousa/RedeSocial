namespace rede_social_domain.Models.Standard
{
    public class StandardModel
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset LastUpdate { get; set; } = DateTime.UtcNow;
    }
}
