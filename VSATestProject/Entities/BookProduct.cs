namespace VSATestProject.Entities;

public class BookProduct
{
    public Guid Id { get; set; }
    
    public Book Book { get; set; }
    
    public long Count { get; set; }
}