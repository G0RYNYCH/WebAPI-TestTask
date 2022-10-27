namespace Codern.Recruitment.Modelling;

public interface IWallet
{
    decimal GetBalance(User user);
    decimal PossitiveTransaction(User user, decimal amount);
    decimal NegativeTransaction(User user, decimal amount);
     
}