using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperProductRepository(conn);

Console.WriteLine("What do you want to do with your database?");
Console.WriteLine("1. Creat a Product");
Console.WriteLine("2. Update a Product");
Console.WriteLine("3. Delete a Product");
Console.WriteLine("4. Get All Products");

var choice = int.Parse(Console.ReadLine());

switch (choice)
{
    case 1:
        Console.WriteLine("What is the name of your new product?");
        var prodName = Console.ReadLine();

        Console.WriteLine("What is the price?");
        var prodPrice = double.Parse(Console.ReadLine());

        Console.WriteLine("What is the category ID?");
        var prodCat = int.Parse(Console.ReadLine());

        repo.CreatProduct(prodName, prodPrice, prodCat);

        var prodList = repo.GetAllProducts();

        foreach (var prod in prodList)
        {
            Console.WriteLine($"{prod.ProductId} - {prod.Name}");

        }
        break;

    case 2:
        Console.WriteLine("What is the product ID you want to update?");
        var prodID = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the new product name?");
        var newName = Console.ReadLine();

        repo.UpdateProduct(prodID, newName);

        var prodList1 = repo.GetAllProducts();

        foreach (var prod in prodList1)
        {
            Console.WriteLine($"{prod.ProductId} - {prod.Name}");

        }
        break;

    case 3:
        Console.WriteLine("What is the product ID you want to delete?");
        prodID = int.Parse(Console.ReadLine());

        repo.DeleteProduct(prodID);
        Console.WriteLine($"ProductID: {prodID} - Successfully Deleted!");
        break;
    case 4:
        var prodList2 = repo.GetAllProducts();

        foreach (var prod in prodList2)
        {
            Console.WriteLine($"{prod.ProductId}: - {prod.Name}");

        }
        break;

    default: Console.WriteLine("Try Again");
        break;

}


