namespace Silicon_1.Models;

public class ContactRequest
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? ServiceId { get; set; }
    public string? ContactMessage { get; set; }
}
