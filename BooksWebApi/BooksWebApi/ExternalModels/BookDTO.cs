using System;

namespace BooksWebApi.ExternalModels
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public AuthorDTO Author { get; set; }
    }
}
