using System.Collections.Generic;
using System.Threading.Tasks;
using WookieBooks.DTO;

namespace WookieBooks.Service
{
    public interface IBookService
    {
        Task<Response<Book>> AddBook(Book book);
        Task<Response<Book>> DeleteBookById(int id);
        Task<Response<Book>> GetBookById(int id);
        Task<Response<IEnumerable<Book>>> GetAllBook();
        Task<Response<Book>> UpdateBook(Book entity);
    }
}
