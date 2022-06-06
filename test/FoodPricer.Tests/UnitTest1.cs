using Xunit;
using System;
using System.
namespace FoodPricer.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
var price = new App().Compute("assiette", "couscous", "coca", "moyen", "baba", "normal", "yes");

      using var writer = new StringWriter();
      Console.SetOut(writer);
      Console.SetError(writer);
      Program.Main(new string[]{});
      var sut = writer.ToString();

    }
}