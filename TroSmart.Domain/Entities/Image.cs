
namespace TroSmart.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public Guid PropertyId { get; set; }
        public virtual Property? Property { get; set; }
    }
}