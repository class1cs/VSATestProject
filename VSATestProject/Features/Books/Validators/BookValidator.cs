using FluentValidation;
using VSATestProject.Dtos;

namespace VSATestProject.Features.Books.Validators;

public class BookValidator : AbstractValidator<CreateBook.CreateBookRequest> 
{
    public BookValidator() 
    {
        RuleFor(x => x.Name).Length(1, 50).NotEmpty();
        RuleFor(x => x.Author).Length(1, 30).NotEmpty();
        RuleFor(x => x.Price).InclusiveBetween(100, decimal.MaxValue);
    }
}