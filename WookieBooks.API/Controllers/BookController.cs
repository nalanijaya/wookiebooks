using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WookieBooks.DTO;
using WookieBooks.Service;


namespace WookieBooks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        #region Private Properties
        private readonly IBookService _bookService;
        private readonly ILogger _logger;
        #endregion

        #region Constructor
        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>All books</returns>
        [HttpGet("all-books")]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _bookService.GetAllBook();
                    if (result != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }
                }
                else
                {
                    return BadRequest(modelState: ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>Book that matches the id</returns>
        [HttpGet("{bookId}")]
        public async Task<IActionResult> Get(int bookId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _bookService.GetBookById(bookId);
                    if (result != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }
                }
                else
                {
                    return BadRequest(modelState: ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
        }

        /// <summary>
        /// Create book
        /// </summary>
        /// <param name="book">Book data</param>
        /// <returns>Created book</returns>
        [HttpPost("create-book")]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _bookService.AddBook(book);
                    if (result != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }
                }
                else
                {
                    return BadRequest(modelState: ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
        }

        /// <summary>
        /// Remove book using id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Removed book</returns>
        [HttpGet("remove-book/{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _bookService.DeleteBookById(id);
                    if (result != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }
                }
                else
                {
                    return BadRequest(modelState: ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
        }

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="book">Book with updated values</param>
        /// <returns>Updated book</returns>
        [HttpPost("update-book")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _bookService.UpdateBook(book);
                    if (result != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }
                }
                else
                {
                    return BadRequest(modelState: ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
        }

        #endregion
    }
}
