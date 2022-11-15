using System.Collections.Generic;

namespace ProductCategory.Repository.Model
{
    public class CustomProductRes
    {
        public bool Success { get; set;}
        public object Results { get; set; }
        public List<string> Messages { get; set; }
    }
}
