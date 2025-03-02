namespace WebApi.Entity
{
    public class BaseEntiity
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; } // Required for RLS
    }
}
