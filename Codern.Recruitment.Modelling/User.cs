namespace Codern.Recruitment.Modelling;
public class User
{
    public Guid Id { get; set; }
    public bool IsVip { get; set; }
    public decimal Amount { get; set; }
    public List<string> Transactions { get; set; }
}
