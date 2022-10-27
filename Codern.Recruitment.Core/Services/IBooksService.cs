using Codern.Recruitment.Core.Dtos;
using Codern.Recruitment.Dal.Entities;

namespace Codern.Recruitment.Core.Services;

public interface IBooksService
{
    Task<IEnumerable<BookDto>> GetPageAsync(DateTime? createdFrom, DateTime? createdTo, int pageNumber, int pageSize,
        CancellationToken cancellationToken);

    Task<Book> UpdateAsync(UpdateBookDto updateBookDto, CancellationToken cancellationToken);
}