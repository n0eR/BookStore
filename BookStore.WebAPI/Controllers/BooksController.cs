using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.BLL.Contracts;
using BookStore.BLL.Implementation;
using BookStore.Client.DTO;
using BookStore.Client.Requests.Create;
using BookStore.Client.Requests.Update;
using BookStore.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BookStore.WebAPI.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {

        private ILogger<BooksController> Logger { get; }
        private IBookCreateService BookCreateService { get; }
        private IBookGetService BookGetService { get; }
        private IBookUpdateService BookUpdateService { get; }
        private IMapper Mapper { get; }

        public BooksController(ILogger<BooksController> logger, IBookCreateService bookCreateService, IBookGetService bookGetService, IBookUpdateService bookUpdateService, IMapper mapper)
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
        public async Task<IActionResult> Index()
        {
            var list = Mapper.Map<IEnumerable<BookDTO>>(await BookGetService.GetAsync());

            return View(list);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = Mapper.Map<BookDTO>(await BookGetService.GetAsync(new BookIdentityModel((int)id)));

            if (book is null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        [Route("new")]
        public ActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("new")]
        public async Task<IActionResult> Create(BookCreateDTO bookCreate)
        {
            try
            {
                var book = Mapper.Map<BookDTO>(
                    await BookCreateService.CreateAsync(Mapper.Map<BookUpdateModel>(bookCreate)));
                return Redirect($"/books/{book.Id}");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = Mapper.Map<BookDTO>(await BookGetService.GetAsync(new BookIdentityModel((int)id)));
            if (book is null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id, BookUpdateDTO updatedBook)
        {
            if (id != updatedBook.Id)
            {
                return NotFound();
            }

            var book =
                Mapper.Map<BookDTO>(await BookUpdateService.UpdateAsync(Mapper.Map<BookUpdateModel>(updatedBook)));
            return Redirect($"/books/{book.Id}");

        }

    }
}
