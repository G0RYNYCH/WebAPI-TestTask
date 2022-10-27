namespace Codern.Recruitment.Core.Dtos;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}