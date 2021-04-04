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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.DataAccess.Context;
using BookStore.DataAccess.Entities;
using BookStore.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BookStore.WebAPI.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private ILogger<OrdersController> Logger { get; }
        private IOrderCreateService OrderCreateService { get; }
        private IOrderGetService OrderGetService { get; }
        private IOrderUpdateService OrderUpdateService { get; }
        private IBookGetService BookGetService { get; }
        private ICustomerGetService CustomerGetService { get; }
        private IMapper Mapper { get; }

        public OrdersController(ILogger<OrdersController> logger, IOrderCreateService orderCreateService, IOrderGetService orderGetService, IOrderUpdateService orderUpdateService, IBookGetService bookGetService, ICustomerGetService customerGetService, IMapper mapper)
        {
            Logger = logger;
            OrderCreateService = orderCreateService;
            OrderGetService = orderGetService;
            OrderUpdateService = orderUpdateService;
            BookGetService = bookGetService;
            CustomerGetService = customerGetService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IActionResult> Index()
        {
            return View(Mapper.Map<IEnumerable<OrderDTO>>(await OrderGetService.GetAsync()));
        }

        [Route("{id}")]
        [Route("get/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = Mapper.Map<OrderDTO>(await OrderGetService.GetAsync(new OrderIndentityModel((int) id)));

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpGet]
        [Route("new")]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            ViewData["BookId"] = new SelectList(Mapper.Map<IEnumerable<BookDTO>>(await BookGetService.GetAsync()), "Id", "Title");
            ViewData["CustomerId"] = new SelectList(Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync()), "Id", "FullName");
            return View();
        }

        [HttpPost]
        [Route("new")]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateDTO orderCreate)
        {
            try
            {
                var order =
                    Mapper.Map<OrderDTO>(
                        await OrderCreateService.CreateAsync(Mapper.Map<OrderUpdateModel>(orderCreate)));
                return Redirect($"/orders/{order.Id}");
            }
            catch
            {
                ViewData["BookId"] = new SelectList(Mapper.Map<IEnumerable<BookDTO>>(await BookGetService.GetAsync()), "Id", "Title");
                ViewData["CustomerId"] = new SelectList(Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync()), "Id", "FullName");
                return View();
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = Mapper.Map<OrderDTO>(await OrderGetService.GetAsync(new OrderIndentityModel((int)id)));
            if (order == null)
            {
                return NotFound();
            }

            var updateDto = new OrderUpdateDTO
            {
                Id = order.Id,
                Arrived = order.Arrived,
                CustomerId = order.Customer.Id,
                BookId = order.Book.Id,
                Date = order.Date
            };

            ViewData["BookId"] = new SelectList(Mapper.Map<IEnumerable<BookDTO>>(await BookGetService.GetAsync()), "Id", "Title", updateDto.BookId);
            ViewData["CustomerId"] = new SelectList(Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync()), "Id", "FullName", updateDto.CustomerId);
            return View(updateDto);
        }


        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderUpdateDTO orderUpdate)
        {
            if (id != orderUpdate.Id)
            {
                return NotFound();
            }

            var order = Mapper.Map<OrderDTO>(await OrderUpdateService.UpdateAsync(Mapper.Map<OrderUpdateModel>(orderUpdate)));
            
            return Redirect($"/orders/{order.Id}");
        }
    }
}
