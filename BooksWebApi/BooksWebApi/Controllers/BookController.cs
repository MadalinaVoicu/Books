using AutoMapper;
using BooksWebApi.Entities;
using BooksWebApi.ExternalModels;
using BooksWebApi.Services.UnitsOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BooksWebApi.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookUnitOfWork _bookUnit;
        private readonly IMapper _mapper;

        public BookController(IBookUnitOfWork bookUnit,
            IMapper mapper)
        {
            _bookUnit = bookUnit ?? throw new ArgumentNullException(nameof(bookUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Books
        [HttpGet, Authorize]
        [Route("{id}", Name = "GetBook")]
        public IActionResult GetBook(Guid id)
        {
            var bookEntity = _bookUnit.Books.Get(id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDTO>(bookEntity));
        }

        [HttpGet, Authorize]
        [Route("", Name = "GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var bookEntities = _bookUnit.Books.Find(a => a.Deleted == false || a.Deleted == null);
            if (bookEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<BookDTO>>(bookEntities));
        }

        [HttpGet, Authorize]
        [Route("details/{id}", Name = "GetBookDetails")]
        public IActionResult GetBookDetails(Guid id)
        {
            var bookEntity = _bookUnit.Books.GetBookDetails(id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDTO>(bookEntity));
        }

        [Route("add", Name = "Add a new book")]
        [HttpPost, Authorize]
        public IActionResult AddBook([FromBody] BookDTO book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            _bookUnit.Books.Add(bookEntity);

            _bookUnit.Complete();

            _bookUnit.Books.Get(bookEntity.Id);

            return CreatedAtRoute("GetBook",
                new { id = bookEntity.Id },
                _mapper.Map<BookDTO>(bookEntity));
        }
        #endregion Books

        #region Authors
        [HttpGet, Authorize]
        [Route("author/{authorId}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorEntity = _bookUnit.Authors.Get(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDTO>(authorEntity));
        }

        [HttpGet, Authorize]
        [Route("author", Name = "GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            var authorEntities = _bookUnit.Authors.Find(a => a.Deleted == false || a.Deleted == null);
            if (authorEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<AuthorDTO>>(authorEntities));
        }

        [Route("author/add", Name = "Add a new author")]
        [HttpPost, Authorize]
        public IActionResult AddAuthor([FromBody] AuthorDTO author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _bookUnit.Authors.Add(authorEntity);

            _bookUnit.Complete();

            _bookUnit.Authors.Get(authorEntity.Id);

            return CreatedAtRoute("GetAuthor",
                new { authorId = authorEntity.Id },
                _mapper.Map<AuthorDTO>(authorEntity));
        }

        [Route("author/{authorId}", Name = "Mark author as deleted")]
        [HttpPut, Authorize]
        public IActionResult MarkAuthorAsDeleted(Guid authorId)
        {
            var author = _bookUnit.Authors.FindDefault(a => a.Id.Equals(authorId) && (a.Deleted == false || a.Deleted == null));
            if (author != null)
            {
                author.Deleted = true;
                if (_bookUnit.Complete() > 0)
                {
                    return Ok("Author " + authorId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Authors
    }
}
