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
using BookStore.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BookStore.WebAPI.Controllers.API
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private ILogger<OrdersApiController> Logger { get; }
        private IOrderCreateService OrderCreateService { get; }
        private IOrderGetService OrderGetService { get; }
        private IOrderUpdateService OrderUpdateService { get; }
        private IMapper Mapper { get; }

        public OrdersApiController(ILogger<OrdersApiController> logger, IOrderCreateService orderCreateService, IOrderGetService orderGetService, IOrderUpdateService orderUpdateService, IMapper mapper)
        {
            Logger = logger;
            OrderCreateService = orderCreateService;
            OrderGetService = orderGetService;
            OrderUpdateService = orderUpdateService;
            Mapper = mapper;
        }

        // GET: api/orders
        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            return Mapper.Map<IEnumerable<OrderDTO>>(await OrderGetService.GetAsync());
        }

        // GET api/orders/5
        [HttpGet]
        [Route("{id}")]
        [Route("get/{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            return Mapper.Map<OrderDTO>(await OrderGetService.GetAsync(new OrderIndentityModel(id)));
        }

        // POST api/orders/create
        [HttpPost]
        [Route("create")]
        [Route("new")]
        public async Task<OrderDTO> Create(OrderCreateDTO orderCreate)
        {
            return Mapper.Map<OrderDTO>(await OrderCreateService.CreateAsync(Mapper.Map<OrderUpdateModel>(orderCreate)));
        }

        // POST api/orders/edit
        [HttpPost]
        [Route("edit/{id?}")]
        public async Task<OrderDTO> Edit([FromRoute] int? id, [FromBody] OrderUpdateModel updateModel)
        {
            if (id.HasValue && id != updateModel.Id)
            {
                throw new InvalidDataException(nameof(id));
            }
            return Mapper.Map<OrderDTO>(await OrderUpdateService.UpdateAsync(Mapper.Map<OrderUpdateModel>(updateModel)));
        }
    }
}
