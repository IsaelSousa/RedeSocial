using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_domain.Models.EFModels
{
    public class FriendsEF
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FriendId { get; set; }
        public string FriendUserName { get; set; }
        public bool FriendAccept { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
