using Microsoft.EntityFrameworkCore;

namespace Codern.Recruitment.Dal.Entities;

[Index(nameof(Isbn), IsUnique = true)]
public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}