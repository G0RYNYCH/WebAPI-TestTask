using Codern.Recruitment.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Codern.Recruitment.Dal.Repositories;

internal class BooksRepository : IBooksRepository
{
    private readonly CodernDbContext _dbContext;
    private readonly ILogger _logger;

    public BooksRepository(CodernDbContext dbContext, ILogger logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }


    public async Task<IEnumerable<Book>> GetPageAsync(DateTime? createdFrom, DateTime? createdTo, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = _dbContext.Books.AsQueryable();

        if (createdFrom.HasValue)
        {
            query = query.Where(x => x.CreatedAtUtc >= createdFrom);
        }

        if (createdTo.HasValue)
        {
            query = query.Where(x => x.CreatedAtUtc <= createdTo);
        }

        if (pageNumber == 1)
        {
            return await query.Skip(0).Take(pageSize).ToListAsync(cancellationToken);
        }

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        try
        {
            var existingBook = await _dbContext.Books.FirstAsync(x => x.Id == book.Id, cancellationToken);

            existingBook.Title = book.Title;
            existingBook.Isbn = book.Isbn;
            existingBook.UpdatedAtUtc = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
        }

        //if (book is null)
        //{
        //    return null;
        //}

        //if (string.IsNullOrWhiteSpace(title))
        //{
        //    book.Isbn = isbn;
        //    book.UpdatedAtUtc = DateTime.UtcNow;
        //}

        //if (string.IsNullOrWhiteSpace(isbn))
        //{
        //    book.Title = title;
        //    book.UpdatedAtUtc = DateTime.UtcNow;
        //}
    }

    public async Task<bool> CheckIsbnAsync(string isbn, CancellationToken cancellationToken)
    {
        var existingIsbn = await _dbContext.Books.FirstOrDefaultAsync(x => x.Isbn == isbn, cancellationToken);

        if (existingIsbn is null)
            return true;
        return false;
    }
}