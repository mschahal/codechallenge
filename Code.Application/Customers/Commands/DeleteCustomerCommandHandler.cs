using Code.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly CustomerContext _context;

        public DeleteCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            if (customer == null)
            {
                return Unit.Value;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
