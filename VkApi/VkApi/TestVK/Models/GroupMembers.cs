using System.Collections.Generic;

namespace VkApi.TestVK.Models
{
    public class GroupMembers
    {
        public GroupResponse GropResponse { get; set; }
    }

    public class GroupResponse
    {
        public int Count { get; set; }
        public List<int> Users { get; set; }
    }

}
