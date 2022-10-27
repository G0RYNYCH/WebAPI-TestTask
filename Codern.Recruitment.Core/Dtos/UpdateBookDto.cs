namespace Codern.Recruitment.Core.Dtos;
public class UpdateBookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
}
