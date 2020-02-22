using System.Collections.Generic;

namespace Dort.Entity.GoogleBook
{
    public class SearchReponse
    {
        public string Kind { get; set; }
        public int TotalItems { get; set; }
        public List<Item> Items { get; }

        public SearchReponse()
        {
            Items = new List<Item>();
        }
    }
}
