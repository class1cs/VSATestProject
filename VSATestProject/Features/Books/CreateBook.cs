using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Dtos;
using VSATestProject.Entities;
using VSATestProject.Exceptions;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace VSATestProject.Features.Books;

public static class CreateBook
{
    public class CreateBookRequest
    {
        public string Name { get; set; }
        
        public string Author { get; set; }
        
        public decimal Price { get; set; }
    }
    
    public class CreateBookHandler
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IValidator<CreateBookRequest> _validator;

        public CreateBookHandler(ApplicationContext dbContext, IValidator<CreateBookRequest> validator)
        {
            _applicationContext = dbContext;
            _validator = validator;
        }
        public async Task<Book> HandleAsync(CreateBook.CreateBookRequest request)
        {
            var validateResult = await _validator.ValidateAsync(request);
            if (!validateResult.IsValid)
            {
                throw new CustomException(validateResult.Errors.Select(x => x.ErrorMessage).ToList(), "Validation error happened.", 400);
            }
            var book = new Book
            {
                Name = request.Name,
                Author = request.Author,
                Price = request.Price
            };
            
            await _applicationContext.Books.AddAsync(book);
            await _applicationContext.SaveChangesAsync();
            return book;
        }
    }
}