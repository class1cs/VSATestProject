namespace VSATestProject.Entities;

public class Purchase
{
    public Guid Id { get; set; }
    
    public List<BookProduct> BookPurchases { get; set; }
    
    public decimal TotalCost { get; set; }

    public Purchase()
    {
        TotalCost = BookPurchases.Select(x => x.Book.Price * x.Count).Sum();
    }
}