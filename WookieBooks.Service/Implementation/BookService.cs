using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WookieBooks.DTO;
using WookieBooks.Repository;
using WookieBooks.Utility.Properties;

namespace WookieBooks.Service
{
    /// <summary>
    /// Book service which contains book CRUD operations
    /// </summary>
    public class BookService : IBookService
    {
        #region Private Properties
        private readonly IBookRepository _bookRepository;
        private readonly ILogger _logger;
        #endregion

        #region Conctructor
        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        #endregion

        #region Public Methods
        public async Task<Response<Book>> AddBook(Book book)
        {
            Response<Book> result = new Response<Book>();
            try
            {

                var addedBook = await _bookRepository.Add(book);
                result.ResultData = addedBook;

                if (result.ResultData != null)
                {
                    result.MessageCode = "WB009";
                    result.Message = wb_resource.WB009;
                }
                else
                {
                    result.MessageCode = "WB012";
                    result.Message = wb_resource.WB012;
                }
            }
            catch (Exception ex)
            {
                result.ErrorList.Add(new ErrorInfo
                {
                    ErrorCode = "WB001",
                    ErrorMessage = wb_resource.WB001
                });
                _logger.LogError(ex.StackTrace);
            }

            return result;
        }

        public async Task<Response<Book>> DeleteBookById(int id)
        {
            Response<Book> result = new Response<Book>();
            try
            {

                var deletedItem = await _bookRepository.Delete(id);
                result.ResultData = deletedItem;

                if (result.ResultData != null)
                {
                    result.MessageCode = "WB010";
                    result.Message = wb_resource.WB010;
                }
                else
                {
                    result.MessageCode = "WB011";
                    result.Message = wb_resource.WB011;
                }
            }
            catch (Exception ex)
            {
                result.ErrorList.Add(new ErrorInfo
                {
                    ErrorCode = "WB002",
                    ErrorMessage = wb_resource.WB002
                });
                _logger.LogError(ex.StackTrace);
            }

            return result;
        }

        public async Task<Response<IEnumerable<Book>>> GetAllBook()
        {
            Response<IEnumerable<Book>> result = new Response<IEnumerable<Book>>();
            try
            {

                var allItems = await _bookRepository.GetAll();
                result.ResultData = allItems;

                if (result.ResultData != null)
                {
                    result.MessageCode = "WB008";
                    result.Message = wb_resource.WB008;
                }
            }
            catch (Exception ex)
            {
                result.ErrorList.Add(new ErrorInfo
                {
                    ErrorCode = "WB003",
                    ErrorMessage = wb_resource.WB003
                });
                _logger.LogError(ex.StackTrace);
            }

            return result;
        }

        public async Task<Response<Book>> GetBookById(int id)
        {
            Response<Book> result = new Response<Book>();
            try
            {

                var exisitingItem = await _bookRepository.Get(id);
                result.ResultData = exisitingItem;


                if (result.ResultData != null)
                {
                    result.MessageCode = "WB008";
                    result.Message = wb_resource.WB008;
                }
                else
                {
                    result.MessageCode = "WB011";
                    result.Message = wb_resource.WB011;
                }
            }
            catch (Exception ex)
            {
                result.ErrorList.Add(new ErrorInfo
                {
                    ErrorCode = "WB004",
                    ErrorMessage = wb_resource.WB004
                });
                _logger.LogError(ex.StackTrace);
            }

            return result;
        }

        public async Task<Response<Book>> UpdateBook(Book entity)
        {
            Response<Book> result = new Response<Book>();
            try
            {

                var updatedItem = await _bookRepository.Update(entity);
                result.ResultData = updatedItem;

                if (result.ResultData != null)
                {
                    result.MessageCode = "WB009";
                    result.Message = wb_resource.WB009;
                }
                else
                {
                    result.MessageCode = "WB011";
                    result.Message = wb_resource.WB011;
                }
            }
            catch (Exception ex)
            {
                result.ErrorList.Add(new ErrorInfo
                {
                    ErrorCode = "WB005",
                    ErrorMessage = wb_resource.WB005
                });
                _logger.LogError(ex.StackTrace);
            }

            return result;
        }
        #endregion
    }
}
