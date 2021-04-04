using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.BLL.Contracts;
using BookStore.Client.DTO;
using BookStore.Client.Requests.Create;
using BookStore.Client.Requests.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.DataAccess.Context;
using BookStore.DataAccess.Entities;
using BookStore.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BookStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksApiController : Controller
    {
        private ILogger<BooksApiController> Logger { get; }
        private IBookCreateService BookCreateService { get; }
        private IBookGetService BookGetService { get; }
        private IBookUpdateService BookUpdateService { get; }
        private IMapper Mapper { get; }

        public BooksApiController(ILogger<BooksApiController> logger, IBookCreateService bookCreateService, IBookGetService bookGetService, IBookUpdateService bookUpdateService, IMapper mapper)
        {
            Logger = logger;
            BookCreateService = bookCreateService;
            BookGetService = bookGetService;
            BookUpdateService = bookUpdateService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            return Mapper.Map<IEnumerable<BookDTO>>(await BookGetService.GetAsync());
        }


        [HttpGet]
        [Route("{bookId}")]
        [Route("get/{bookId}")]
        public async Task<BookDTO> Get(int bookId)
        {
            return Mapper.Map<BookDTO>(await BookGetService.GetAsync(new BookIdentityModel(bookId)));
        }

        [HttpPost]
        [Route("create")]
        [Route("new")]
        public async Task<BookDTO> Create(BookCreateDTO book)
        {
            var result = await BookCreateService.CreateAsync(Mapper.Map<BookUpdateModel>(book));

            return Mapper.Map<BookDTO>(result);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<BookDTO> Edit(BookUpdateDTO book)
        {
            var result = await BookUpdateService.UpdateAsync(Mapper.Map<BookUpdateModel>(book));

            return Mapper.Map<BookDTO>(result);
        }
    }
}
