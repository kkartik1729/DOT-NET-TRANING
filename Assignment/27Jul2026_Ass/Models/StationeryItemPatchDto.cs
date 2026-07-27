namespace StationeryApi.Models
{
    // Used for PATCH requests: only the fields the client sends are updated.
    public class StationeryItemPatchDto
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
