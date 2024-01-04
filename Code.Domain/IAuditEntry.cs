
namespace Code.Domain
{
    public interface IAuditEntry
    {
        DateTime CreatedDateTime { get; set; }
        DateTime LastUpdatedDateTime { get; set; }
    }
}
