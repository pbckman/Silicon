using System.ComponentModel.DataAnnotations;

namespace Silicon_1.Models;

public class ContactRequestViewModel
{

    public IEnumerable<ContactRequest>? ContactRequests { get; set; }

    public IEnumerable<Service>? Service { get; set; }

    [Display(Name = "Full name", Prompt = "Enter your full name")]
    [MinLength(4, ErrorMessage = "A valid full name is required")]
    public string? FullName { get; set; }

    [Display(Name = "Email", Prompt = "Enter your email")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }

    [Display(Name = "Message", Prompt = "Enter your message")]
    public string? ContactMessage { get; set; }

    [Display(Name = "Service (Optional)", Prompt = "Choose the service you are intrested in")]
    public int? ServiceId { get; set; }
}
