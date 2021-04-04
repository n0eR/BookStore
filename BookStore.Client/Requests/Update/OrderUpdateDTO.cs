using BookStore.Client.Requests.Create;

namespace BookStore.Client.Requests.Update
{
    public class OrderUpdateDTO : OrderCreateDTO
    {
        public int Id { get; set; }
    }
}