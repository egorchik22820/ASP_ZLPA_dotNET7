namespace ASP_ZALUUPA.Domain.Entities
{
    public class ServicePhoto
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public byte[] Data { get; set; } = null!;

        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
