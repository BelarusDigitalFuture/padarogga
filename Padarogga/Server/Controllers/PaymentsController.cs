using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Padarogga.Server.Services;

namespace Padarogga.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly ICustomerService customerService;

        public PaymentsController(IPaymentService paymentService, ICustomerService authorService)
        {
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            this.customerService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        string userId = "df9d86e4-3dad-40e1-8986-00bda7847b4f";

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //TODO add paging
            //TODO get userId by context
            var author = await customerService.GetByUserId(userId);
            var payments = await paymentService.GetByAuthorAsync(author.Id);
            return Ok(payments);
        }


        [HttpPost]
        public async Task<ActionResult> Add()
        {
            //TODO add paging
            //TODO get userId by context
            var author = await customerService.GetByUserId(userId);
            var payments = await paymentService.GetByAuthorAsync(author.Id);
            return Ok(payments);
        }
    }
}
