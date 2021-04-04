using System.ComponentModel.DataAnnotations;

namespace BookStore.Client.Requests.Create
{
    public class CustomerCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Addres { get; set; }

        public string Phone { get; set; }
    }
}