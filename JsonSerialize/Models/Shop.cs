using System.Collections.Generic;

namespace JsonSerialize.Object
{
    public class Shop
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Phone> Phones { get; set; }
    }
    
}