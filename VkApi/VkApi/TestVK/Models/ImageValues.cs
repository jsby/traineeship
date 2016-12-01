using System.Collections.Generic;

namespace VkApi.TestVK.Models
{
    public class ImageValues
    {
        public List<Response> Response { get; set; }
    }

    public class Response
    {
        public int Pid { get; set; }
        public string Id { get; set; }
        public int Aid { get; set; }
        public int OwnerId { get; set; }
        public string Src { get; set; }
        public string SrcBig { get; set; }
        public string SrcSmall { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }
        public int Created { get; set; }
    }

}
