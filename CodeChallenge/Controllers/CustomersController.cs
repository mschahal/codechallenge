using Code.Application.Customers.Commands;
using Code.Application.Customers.Queries;
using Code.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/customers
        [HttpGet()]
        public async Task<ActionResult<Customer>> GetCustomers()
        {
            var customer = await _mediator.Send(new GetCustomerQueryable());
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery { Id = id });
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult<int>> CreateCustomer(CreateCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }

        // PUT api/customers/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id != command.Id || !ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        // Delete api/customers
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Ok(await _mediator.Send(new DeleteCustomerCommand() { Id = id}, cancellationToken));
        }


    }
}
