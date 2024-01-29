using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;

namespace VSATestProject.Features.Books;

public class GetAllBooks
{
    public class GetAllBooksHandler
    {
        private readonly ApplicationContext _dbContext;

        public GetAllBooksHandler(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Book>> HandleAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }
    }
}