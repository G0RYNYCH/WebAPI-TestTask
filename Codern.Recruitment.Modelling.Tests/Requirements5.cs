using System.Collections.Generic;
using Xunit;

namespace Codern.Recruitment.Modelling.Tests;

/// <summary>
/// Listing transactions
/// </summary>
public class Requirements5
{
    [Theory]
    [InlineData(0, true)]
    [InlineData(100, true)]
    [InlineData(99999, true)]
    public void Should_List_Positive_Transactions(decimal amount, bool expected)
    {
        User user = new()
        {
            Amount = 0,
            Transactions = new List<string> { }
        };

        Wallet wallet = new Wallet();

        wallet.PossitiveTransaction(user, amount);
        var answer = user.Transactions.Contains($"Plus {amount}.");

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(100, true)]
    [InlineData(99999, false)]
    public void Should_List_Negative_Transactions(decimal amount, bool expected)
    {
        User user = new()
        {
            Amount = 0,
            Transactions = new List<string> { }
        };

        Wallet wallet = new Wallet();

        wallet.NegativeTransaction(user, amount);

        var answer = user.Transactions.Contains($"Minus {amount}.");

        Assert.Equal(expected, answer);   
    }
}