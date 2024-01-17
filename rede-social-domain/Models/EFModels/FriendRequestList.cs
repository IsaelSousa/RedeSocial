namespace rede_social_domain.Models.EFModels
{
    public class FriendRequestList
    {
        public FriendRequestList(long id, string UserName)
        {
            this.Id = id;
            this.UserName = UserName;
        }

        public long Id { get; set; }
        public string UserName { get; set; }
    }
}
