namespace rede_social_domain.Models.EFModels
{
    public class FriendRequestList
    {
        public FriendRequestList(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; set; }
    }
}
