using BookStore.Client.Requests.Create;

namespace BookStore.Client.Requests.Update
{
    public class CustomerUpdateDTO : CustomerCreateDTO
    {
        public int Id { get; set; }
    }
}