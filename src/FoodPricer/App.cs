namespace FoodPricer
{
    using System;

    public interface IFormulaPricedProduct {
      public decimal MaxFormulaPrice {get;}
      public decimal NormalFormulaPrice {get;}
    }
    public interface IPricedProduct{
      public decimal Price {get;}
    }
    public interface IFormulaApplyable{
      public bool NormalFormula {get;} 
      public bool MaxFormula {get;} 
    }

    public interface IMeal: IFormulaPricedProduct, IPricedProduct{
      
    }
    public interface IExtraProduct: IFormulaApplyable, IPricedProduct{
      
    }

    public class Plate : IMeal {
      public decimal Price => 15;
      public decimal NormalFormulaPrice => 18;
      public decimal MaxFormulaPrice => 21;
    }
    public class Sandwich: IMeal {
      public decimal Price=> 10;
      public decimal NormalFormulaPrice => 13;
      public decimal MaxFormulaPrice => 16;
    }
    public class SmallSizeBeverage: IExtraProduct{
      public decimal Price => 2;
      public bool NormalFormula => false;
      public bool MaxFormula => false;
    }
    public class MiddleSizeBeverage: IExtraProduct{
      public decimal Price => 3;
      public bool NormalFormula => true;
      public bool MaxFormula => false;
    }
    public class BigSizeBeverage: IExtraProduct{
      public decimal Price => 4;
      public bool NormalFormula => false;
      public bool MaxFormula => true;
    }

    public class NormalDesert: IExtraProduct{
      public decimal Price => 2;
      public bool NormalFormula => true;
      public bool MaxFormula => true;
    } 

    public class ExtraDesert: IExtraProduct{
      public decimal Price => 4;
      public bool NormalFormula => false;
      public bool MaxFormula => false;
    } 


    public class Formula{
      private readonly decimal _price;
      public decimal Price => _price;
      public string? Message {get;private set;}
      
      public Formula(IMeal meal, IExtraProduct beverage, IExtraProduct desert ){
        if(beverage.MaxFormula && desert.MaxFormula){
          _price = meal.MaxFormulaPrice;
          Message = "Prix Formule Standard appliquée ";
        } else if(beverage.NormalFormula && desert.NormalFormula){
          _price = meal.NormalFormulaPrice;
          Message = "Prix Formule Max appliquée ";
        } else {
          _price = meal.Price + beverage.Price + desert.Price;
        }
      }
    }

  
    public static class MealFactory{
      public static IMeal? NewMeal(string type) => type switch{
          "assiette" => new Plate(),
          "sandwich" => new Sandwich(),
          _ => null
      };
    }
    public static class BeverageFactory{
      public static IExtraProduct? NewBeverage(string type) => type switch{
          "petit" => new SmallSizeBeverage(),
          "moyen" => new MiddleSizeBeverage(),
          "grand" => new BigSizeBeverage(),
          _ => null
      };
    }
      public static class DesertFactory{
      public static IExtraProduct? NewDesert(string type) => type switch{
          "normal" => new NormalDesert(),
          _ => new ExtraDesert()
      };
    }



    public class App
    {
        
        //calcule le prix payé par l'utilisateur dans le restaurant, en fonction de type de 
        //repas qu'il prend (assiette ou sandwich), de la taille de la boisson (petit, moyen, grand), du dessert et
        //de son type (normal ou special) et si il prend un café ou pas (yes ou no).
        //les prix sont fixes pour chaque type de chose mais des réductions peuvent s'appliquer
        //si cela rentre dans une formule!
        public double Compute(string type, string name, string beverage, string size, string dessert, string dsize, string coffee)
        {
            //prix total à payer pour le client
            int total = 0;
            
            //le type ne peut être vide car le client doit déclarer au moins un repas
            if(string.IsNullOrEmpty(type+name)) return -1;

            var meal = MealFactory.NewMeal(type);
            var sizedBeverage = BeverageFactory.NewBeverage(size);
            var typedDesert = DesertFactory.NewDesert(dsize);
            var formula = new Formula(meal, sizedBeverage, typedDesert);
            Console.WriteLine(formula.Message);
            return (double)formula.Price;
            //si le client prends un plat en assiette
        }
    }
}