using Silicon_1.Filters;
using System.ComponentModel.DataAnnotations;

namespace Silicon_1.Models;

public class SignUpViewModel
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

    [Required]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [CheckboxValidation]
    [Display(Name = "Terms & Conditions", Prompt = "I agree to the terms and conditions")]
    public bool TermsAndConditions { get; set; }
}
