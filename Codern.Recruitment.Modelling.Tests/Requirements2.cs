using System;
using System.Collections.Generic;
using Xunit;

namespace Codern.Recruitment.Modelling.Tests;

/// <summary>
/// Rounding
/// </summary>
public class Requirements2
{
    [Fact]
    public void Should_Always_Round_Money_Down_To_Two_Decimal_Places()
    {
        User user = new()
        {
            Amount = 10,
            Transactions = new List<string> { }
        };

        Wallet wallet = new Wallet();

        decimal amount = 12.34999999M;
        var answer = wallet.PossitiveTransaction(user, amount);

        Assert.Equal(22.34M, answer);
    }
}