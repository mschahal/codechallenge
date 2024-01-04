using Code.Domain;
using MediatR;

namespace Code.Application.Customers.Queries
{
    public class GetCustomerQueryable : IRequest<IQueryable<Customer>>
    {
    }

    // Query Handler
    public class GetCustomerQueryableHandler : IRequestHandler<GetCustomerQueryable, IQueryable<Customer>>
    {
        private readonly CustomerContext _context;

        public GetCustomerQueryableHandler(CustomerContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Customer>> Handle(GetCustomerQueryable request, CancellationToken cancellationToken)
        {
            return Task.FromResult((IQueryable<Customer>)_context.Customers);
        }
    }
}
