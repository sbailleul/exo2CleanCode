using FoodPricer;

//pour tester, lancer en ligne de commande : 
//dotnet run -- "assiette" "couscous" "coca" "moyen" "baba" "normal" "yes"
var price = new App().Compute(args[0],args[1],args[2],args[3], args[4], args[5], args[6]);

Console.WriteLine($"\nPrix à payer : {price}€");

