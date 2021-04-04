using BookStore.Client.Requests.Create;

namespace BookStore.Client.Requests.Update
{
    public class BookUpdateDTO : BookCreateDTO
    {
        public int Id { get; set; }
    }
}