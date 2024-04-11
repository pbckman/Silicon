namespace Silicon_1.Models;

public class ContactRequestViewModel
{

    public IEnumerable<ContactRequest>? ContactRequests { get; set; }

    public IEnumerable<Service>? Service { get; set; }

    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? ContactMessage { get; set; }

    public int? ServiceId { get; set; }
}
