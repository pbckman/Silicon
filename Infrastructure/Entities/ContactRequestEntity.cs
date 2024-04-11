using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities;

public class ContactRequestEntity
{
    [Key]
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;
    public int? ServiceId { get; set; }

    public string? ContactMessage { get; set; }

    public DateTime Created { get; set; }
}
