using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Domain.Contracts;

namespace BookStore.Domain.Models
{
    public class BookIdentityModel : IBookIdentity
    {
        public int Id { get; }

        public BookIdentityModel(int id)
        {
            Id = id;
        }
    }
}
