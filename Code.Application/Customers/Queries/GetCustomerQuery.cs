using Code.Domain;
using MediatR;

namespace Code.Application.Customers.Queries
{
    public class GetCustomerQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }

    // Query Handler
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly CustomerContext _context;

        public GetCustomerQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers.FindAsync(new object?[] { request.Id }, cancellationToken);
        }
    }
}
