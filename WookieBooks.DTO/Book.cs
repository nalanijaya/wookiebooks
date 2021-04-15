using System.ComponentModel.DataAnnotations;

namespace WookieBooks.DTO
{
    public class Book
    {
        #region Public Property

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public string CoverImage { get; set; }
        [Required]
        public string Price { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
