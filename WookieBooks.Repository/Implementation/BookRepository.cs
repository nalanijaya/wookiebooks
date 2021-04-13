using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WookieBooks.DTO;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace WookieBooks.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;
        private readonly ILogger _logger;

        public BookRepository(ILogger<BookRepository> logger)
        {
            _logger = logger;
            _books = new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    Title="Test Book 1",
                    Description="Test Book 1 Description",
                    Author="Test Book 1 Author",
                    CoverImage="Test Book 1 Cover Image Path",
                    IsActive=true
                },
                 new Book()
                {
                    Id=2,
                    Title="Test Book 2",
                    Description="Test Book 2 Description",
                    Author="Test Book 2 Author",
                    CoverImage="Test Book 2 Cover Image Path",
                    IsActive=true
                }
            };
        }

        public async Task<Book> Add(Book entity)
        {
            try
            {
                _books.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
            
        }

        public async Task<Book> Delete(int id)
        {
            Book book = new Book();
            try
            {
                var existingItem = _books.Where(item => item.Id == id && item.IsActive).FirstOrDefault();

                if (existingItem != null)
                {
                    existingItem.IsActive = false;
                    book = existingItem;
                }

                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        public async Task<Book> Get(int id)
        {
            Book book = new Book();
            try
            {
                var item = _books.Where(im => im.Id == id && im.IsActive).FirstOrDefault();

                if (item != null)
                {
                    book = item; ;
                }

                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return _books.Where(im => im.IsActive);
        }

        public async Task<Book> Update(Book entity)
        {
            Book book = new Book();
            try
            {
                book = _books.Where(item => item.Id == entity.Id && item.IsActive).FirstOrDefault();

                if (book != null)
                {
                    book.Title = entity.Title;
                    book.Description = entity.Description;
                    book.CoverImage = entity.CoverImage;
                    book.Price = entity.Price;
                }

                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }
    }
}
