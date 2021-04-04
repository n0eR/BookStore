using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookStore.Client.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }

        [JsonIgnore]
        public ICollection<OrderDTO> Orders { get; set; }
    }
}
