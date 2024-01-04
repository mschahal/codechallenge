using Microsoft.EntityFrameworkCore;

namespace Code.Domain
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleAuditEntries();
            var saveChanges = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return saveChanges;
        }

        private void HandleAuditEntries()
        {
            var addedAuditedEntities = ChangeTracker.Entries<IAuditEntry>()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity);

            var modifiedAuditedEntities = ChangeTracker.Entries<IAuditEntry>()
                .Where(p => p.State == EntityState.Modified)
                .Select(p => p.Entity);

            var now = DateTime.UtcNow;
            foreach (var added in addedAuditedEntities)
            {

                added.CreatedDateTime = now;
                added.LastUpdatedDateTime = now;
            }

            foreach (var modified in modifiedAuditedEntities)
            {
                modified.LastUpdatedDateTime = now;
            }
        }
    }
}
