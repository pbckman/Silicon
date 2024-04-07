using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class AccountBasicInfoModel
{
    [Required]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string Firstname { get; set; } = null!;

    [Required]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string Lastname { get; set; } = null!;

    [Required]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Bio (Optional)", Prompt = "Add a short bio...")]
    public string? Biography {  get; set; }
}
