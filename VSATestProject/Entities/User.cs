namespace VSATestProject.Entities;

public class User : Account
{
    public string Name { get; set; }
    
    public string SecondName { get; set; }
    
    public string Patronymic { get; set; }

    public decimal Balance { get; set; } = 0;
    
    public List<Purchase> Purchases { get; set; } = new List<Purchase>();
}
