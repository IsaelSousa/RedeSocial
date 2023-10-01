using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Models
{
    public class PostModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string PostMessage { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }

        public PostModel(string id, string firstName, string postMessage, string image, DateTime createdAt, DateTime lastupdated)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.PostMessage = postMessage;
            this.Image = image;
            this.CreatedAt = createdAt;
            this.LastUpdated = lastupdated;
        }
    }
}
