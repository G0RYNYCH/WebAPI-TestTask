using Codern.Recruitment.Core.Dtos;
using Codern.Recruitment.Dal.Entities;
using Codern.Recruitment.Dal.Repositories;

namespace Codern.Recruitment.Core.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<IEnumerable<BookDto>> GetPageAsync(DateTime? createdFrom, DateTime? createdTo, int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var results = await _booksRepository.GetPageAsync(createdFrom, createdTo, pageNumber, pageSize, cancellationToken);

        return results.Select(x => new BookDto
        {
            Id = x.Id,
            Title = x.Title,
            CreatedAtUtc = x.CreatedAtUtc,
            Isbn = x.Isbn
        });
    }

    /// <summary>Updates the asynchronous.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="title">The title.</param>
    /// <param name="isbn">The isbn.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    public async Task<Book> UpdateAsync(UpdateBookDto updateBookDto, CancellationToken cancellationToken)
    {
        Book book = new()
        {
            Title = updateBookDto.Title,
            Isbn = updateBookDto.Isbn,
            UpdatedAtUtc = DateTime.UtcNow
        };
        
        await _booksRepository.UpdateBookAsync(book, cancellationToken);

        return book;
    }
}