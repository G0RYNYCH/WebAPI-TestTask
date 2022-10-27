using Codern.Recruitment.Core.Dtos;
using Codern.Recruitment.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codern.Recruitment.Api.Controllers;

/// <inheritdoc />
[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;
    private readonly ILogger _logger;

    /// <inheritdoc />
    public BooksController(IBooksService booksService, ILogger logger)
    {
        _booksService = booksService;
        _logger = logger;
    }

    /// <summary>
    /// Get books page
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="createdFrom"></param>
    /// <param name="createdTo"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IEnumerable<BookDto>> Get(CancellationToken cancellationToken, DateTime? createdFrom = null, DateTime? createdTo = null, int pageNumber = 1, int pageSize = 10)
    {
        return await _booksService.GetPageAsync(createdFrom, createdTo, pageNumber, pageSize, cancellationToken);
    }

    /// <summary>Updates the specified identifier.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="title">The title.</param>
    /// <param name="isbn">The isbn.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPut]
    public async Task<UpdateBookDto> Update([FromBody] UpdateBookDto updateBookDto, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Book update is starting.");

        await _booksService.UpdateAsync(updateBookDto, cancellationToken);

        _logger.LogInformation("Book update is complited.");

        return updateBookDto;
    }
}