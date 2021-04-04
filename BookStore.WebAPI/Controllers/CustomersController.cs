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
    [Route("customers")]
    public class CustomersController : Controller
    {
        private ILogger<CustomersController> Logger { get; }
        private ICustomerCreateService CustomerCreateService { get; }
        private ICustomerGetService CustomerGetService { get; }
        private ICustomerUpdateService CustomerUpdateService { get; }
        private IOrderGetService OrderGetService { get; }
        private IMapper Mapper { get; }

        public CustomersController(ILogger<CustomersController> logger, ICustomerCreateService customerCreateService, ICustomerGetService customerGetService, ICustomerUpdateService customerUpdateService, IOrderGetService orderGetService, IMapper mapper)
        {
            Logger = logger;
            CustomerCreateService = customerCreateService;
            CustomerGetService = customerGetService;
            CustomerUpdateService = customerUpdateService;
            OrderGetService = orderGetService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IActionResult> Index()
        {
            return View(Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync()));
        }

        [HttpGet]
        [Route("{id}")]
        [Route("get/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var customer = Mapper.Map<CustomerDTO>(await CustomerGetService.GetAsync(new CustomerIndentityModel((int)id)));

            if (customer == null)
            {
                return NotFound();
            }

            ViewData["Orders"] = Mapper.Map<IEnumerable<OrderDTO>>(await OrderGetService.GetByCustomerAsync(new CustomerIndentityModel((int)id)));

            return View(customer);
        }

        [Route("create")]
        [Route("new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [Route("new")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateDTO customerCreate)
        {
            try
            {
                var customer =
                    Mapper.Map<CustomerDTO>(
                        await CustomerCreateService.CreateAsync(Mapper.Map<CustomerUpdateModel>(customerCreate)));
                return Redirect($"/customers/{customer.Id}");
            }
            catch
            {
                return View();
            }
        }

        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer =
                Mapper.Map<CustomerDTO>(await CustomerGetService.GetAsync(new CustomerIndentityModel((int) id)));
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerUpdateDTO customerUpdate)
        {
            if (id != customerUpdate.Id)
            {
                return NotFound();
            }

            var customer = Mapper.Map<CustomerDTO>(await CustomerUpdateService.UpdateAsync(Mapper.Map<CustomerUpdateModel>(customerUpdate)));
            return Redirect($"/customers/{customer.Id}");
        }
    }
}
