using System.Collections.Generic;

namespace VkApi.TestVK.Models
{
    class UserInfo
    {
        public List<User> User { get; set; }
    }
    public class User
    {
        public int Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int City { get; set; }
        public int Country { get; set; }
    }
}
