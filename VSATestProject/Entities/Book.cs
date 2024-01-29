namespace VSATestProject.Entities;


public class Book
{
    public Guid Id { get; set; }
    
    public decimal Price { get; set; }
    
    public string Author { get; set; }
    
    public string Name { get; set; }
}