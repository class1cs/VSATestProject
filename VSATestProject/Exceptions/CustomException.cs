using FluentValidation.Results;

namespace VSATestProject.Exceptions;

public class CustomException : ArgumentException
{
     public List<string> Errors { get; set; }
     
     public int StatusCode { get; set; }
     
     public CustomException(List<string> errors, string message, int statusCode) : base(message)
     {
         Errors = errors;
         StatusCode = statusCode;
     }
}