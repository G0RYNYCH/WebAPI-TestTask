using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Codern.Recruitment.Modelling.Tests;

/// <summary>
/// Basic cases
/// </summary>
public class Requirements1
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(-100, -100)]
    [InlineData(100, 100)]
    public void Should_Return_Balance(decimal amount, decimal expected)
    {
        User user = new User()
        {
            Amount = amount
        };
        Wallet wallet = new Wallet();

        var answer = wallet.GetBalance(user);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 100)]
    public void Should_Make_Positive_Amount_Transaction(decimal amount, decimal expected)
    {
        User user = new()
        {
            Amount = 0,
            Transactions = new List<string> { }
        };

        Wallet wallet = new Wallet();

        var answer = wallet.PossitiveTransaction(user, amount);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, -100)]
    public void Should_Make_Negative_Amount_Transaction(decimal amount, decimal expected)
    {
        User user = new()
        {
            Amount = 0,
            Transactions = new List<string> { }
        };

        Wallet wallet = new Wallet();

        var answer = wallet.NegativeTransaction(user, amount);

        Assert.Equal(expected, answer);
    }
}

//Test