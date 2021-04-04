using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.BLL.Contracts;
using BookStore.Client.DTO;
using BookStore.Client.Requests.Create;
using BookStore.Client.Requests.Update;
using BookStore.Domain.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.WebAPI.Controllers.API
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        private ILogger<CustomersApiController> Logger { get; }
        private ICustomerCreateService CustomerCreateService { get; }
        private ICustomerGetService CustomerGetService { get; }
        private ICustomerUpdateService CustomerUpdateService { get; }
        private IMapper Mapper { get; }

        public CustomersApiController(ILogger<CustomersApiController> logger, ICustomerCreateService customerCreateService, ICustomerGetService customerGetService, ICustomerUpdateService customerUpdateService, IMapper mapper)
        {
            Logger = logger;
            CustomerCreateService = customerCreateService;
            CustomerGetService = customerGetService;
            CustomerUpdateService = customerUpdateService;
            Mapper = mapper;
        }

        // GET: api/customers
        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            return Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync());
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        [Route("get/{id}")]
        public async Task<CustomerDTO> Get(int id)
        {
            return Mapper.Map<CustomerDTO>(await CustomerGetService.GetAsync(new CustomerIndentityModel(id)));
        }

        // POST api/customers/create
        [HttpPost]
        [Route("create")]
        [Route("new")]
        public async Task<CustomerDTO> Create(CustomerCreateDTO customerCreate)
        {
            return Mapper.Map<CustomerDTO>(
                await CustomerCreateService.CreateAsync(Mapper.Map<CustomerUpdateModel>(customerCreate)));
        }

        // POST api/customers/edit
        [HttpPost]
        [Route("edit/{id?}")]
        public async Task<CustomerDTO> Create([FromRoute]int? id,[FromBody]CustomerUpdateDTO customerUpdate)
        {
            if (id.HasValue && id != customerUpdate.Id)
            {
                throw new InvalidDataException(nameof(id));
            }

            return Mapper.Map<CustomerDTO>(
                await CustomerUpdateService.UpdateAsync(Mapper.Map<CustomerUpdateModel>(customerUpdate)));
        }


    }
}
