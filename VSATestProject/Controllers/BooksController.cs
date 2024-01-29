using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSATestProject.Dtos;
using VSATestProject.Entities;
using VSATestProject.Features.Books;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace VSATestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly CreateBook.CreateBookHandler _createBookHandler;
        private readonly GetAllBooks.GetAllBooksHandler _getAllBooksHandler;
        private readonly IValidator<CreateBook.CreateBookRequest> _bookValidator;
        
        public BooksController(CreateBook.CreateBookHandler createBookHandler, 
GetAllBooks.GetAllBooksHandler getAllBooksHandler, IValidator<CreateBook.CreateBookRequest> bookValidator)
        {
            _createBookHandler = createBookHandler;
            _getAllBooksHandler = getAllBooksHandler;
            _bookValidator = bookValidator;

        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateNewBook([FromBody] CreateBook.CreateBookRequest createBookRequest)
        {
            var result = await _createBookHandler.HandleAsync(createBookRequest);
            return Ok(result);
        }
        
        [HttpGet("getAll")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _getAllBooksHandler.HandleAsync();
            return Ok(result);
        }
    }
}