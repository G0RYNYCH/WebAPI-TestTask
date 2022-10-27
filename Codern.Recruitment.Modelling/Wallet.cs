namespace Codern.Recruitment.Modelling;
public class Wallet : IWallet
{
    const decimal Debt = -500;
    const decimal VipDebt = -10000;

    public decimal GetBalance(User user) => user.Amount;

    public decimal PossitiveTransaction(User user, decimal amount)
    {
        var result = RoundDown(user.Amount += amount, 2);
        user.Transactions.Add($"Plus {amount}.");

        return result;
    }

    public decimal NegativeTransaction(User user, decimal amount)
    {
        if ((user.IsVip && user.Amount - amount >= VipDebt) ^ (!user.IsVip && user.Amount - amount >= Debt))
        {
            var result = RoundDown(user.Amount -= amount, 2);
            user.Transactions.Add($"Minus {amount}.");

            return result;
        }
        else
        {
            user.Transactions.Add("Sorry, next time.");

            return user.Amount;
        }
    }

    public decimal RoundDown(decimal i, double decimalPlaces)
    {
        var power = Convert.ToDecimal(Math.Pow(10, decimalPlaces));

        return Math.Floor(i * power) / power;
    }
}
