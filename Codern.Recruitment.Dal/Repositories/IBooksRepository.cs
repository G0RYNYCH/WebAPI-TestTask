using Codern.Recruitment.Dal.Entities;

namespace Codern.Recruitment.Dal.Repositories;

public interface IBooksRepository
{
    Task<IEnumerable<Book>> GetPageAsync(DateTime? createdFrom, DateTime? createdTo, int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task UpdateBookAsync(Book book, CancellationToken cancellationToken);

    Task<bool> CheckIsbnAsync(string isbn, CancellationToken cancellationToken);
}