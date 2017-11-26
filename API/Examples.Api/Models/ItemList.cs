using System.Collections.Generic;

namespace Examples.Api.Models
{
    public class ItemList<TItem>
    {
        public IEnumerable<TItem> Items { get; set; }
        public int TotalCount { get; set; }
    }
}