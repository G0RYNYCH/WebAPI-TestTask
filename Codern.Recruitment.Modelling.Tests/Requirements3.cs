using System;
using System.Collections.Generic;
using Xunit;

namespace Codern.Recruitment.Modelling.Tests;

/// <summary>
/// Vip clients
/// </summary>
public class Requirements3
{
    [Theory]
    [InlineData(true, 10001, 0)]
    [InlineData(true, 9999, -9999)]
    [InlineData(true, 10000, -10000)]
    [InlineData(false, 10000, 0)]
    public void Vip_Client_Can_Have_Max_10k_Debt(bool isVip, decimal amount, decimal expected)
    {
        User user = new()
        {
            IsVip = isVip,
            Amount = 0,
            Transactions = new List<string> { }
        };

        Wallet wallet = new Wallet();

        var answer = wallet.NegativeTransaction(user, amount);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData(false, 999, 0)]
    [InlineData(false, 15, -15)]
    [InlineData(false, 500, -500)]
    [InlineData(true, 999, -999)]
    public void Normal_Client_Can_Have_500_Debt(bool isVip, decimal amount, decimal expected)
    {
        User user = new()
        {
            IsVip = isVip,
            Amount = 0,
            Transactions = new List<string> { }
        };

        Wallet wallet = new Wallet();

        var answer = wallet.NegativeTransaction(user, amount);

        Assert.Equal(expected, answer);
    }
}