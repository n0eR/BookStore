using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookStore.Client.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string FullName { get; set; }

        public string Addres { get; set; }

        public string Phone { get; set; }

        [JsonIgnore]
        public ICollection<OrderDTO> Orders { get; set; }
    }
}