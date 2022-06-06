
## About
This application is used by a restaurant to calculate the price of the orders of its clients.
It works (mostly) and has lots of comments which is good, right ?

But there is no tests and no obvious way to prove that the app is working as expected

## What's my job ?

You need to make this code more robust and bring some quality in. 
This means that you need to bring structure to this actual code, create tests, seperate domain logic and models from infrastructure code

## Tips


### Comments

Think about it, if you need a comment, maybe there is a concept hidden in the code that you encapsulate into a var or a function with a name ?

### Classes

C# is an "object oriented language" but this code is totally imperative code declared within one method.

you can create classes, Enums or records to model your domain:

```csharp
public class Menu
{
  public string MainDish {get;}
  public Menu(string mainDish){
    MainDish = mainDish;
  }
}

public enum Size { XM, S, M, L, XL};
public record Beverage (string Name);
```

you can use lambda functions, generics or interfaces to create the abstractions you need:

```csharp
//a contract(interface) with generic parameters
public interface IMenuBuilder<T,U>
{
    double ComputePrice(T type, U main);
    //a method that uses a delegated abstract function
    void AddComputeOperation(Func<T,double> operation);
    void AddPromotion(string name, Func<T,double> promotion);
}

public static class Utilities
{
 // a function in a variable that uses lambda format and pattern matching
  public static Func<string, double> PriceForFormat {get;} = f => f switch {
      "assiette" => 15,
      "sandwich" => 10,
      _ => -1
    };
}

```