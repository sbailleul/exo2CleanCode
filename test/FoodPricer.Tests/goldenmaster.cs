using Xunit;
using System;
using System.IO;
using NFluent;

namespace FoodPricer.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
      using var writer = new StringWriter();
      Console.SetOut(writer);
      Console.SetError(writer);
      //var price = new App().Compute("assiette", "couscous", "coca", "moyen", "baba", "normal", "yes");
      Program.Main("assiette", "couscous", "coca", "moyen", "baba", "normal", "yes");
      
      var sut = writer.ToString();
      var expected = @"Prix Formule Standard appliquée  avec café offert!
Prix à payer : 18€
";
      Check.That(sut).IsEqualTo(expected);
    }
}