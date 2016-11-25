using System.Collections.Generic;

namespace KasperskyTest.TestKPC.Models
{
    public class Product
    {
        public string Name { get; set; }

        public List<Option> Options { get; set; }

        public Product(string name, List<Option> options)
        {
            Name = name;
            Options = options;
        }

        public int GetOptionsCount()
        {
            return Options.Count;
        }
    }
}
