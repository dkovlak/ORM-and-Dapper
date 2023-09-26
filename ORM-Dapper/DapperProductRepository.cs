using System;
using System.Data;
using Dapper;
namespace ORM_Dapper
{
	public class DapperProductRepository : IProductRepository
	{
        private readonly IDbConnection _connction;

		public DapperProductRepository(IDbConnection connection)
		{
            _connction = connection;
		}

        public void CreatProduct(string name, double price, int categoryID)
        {
            _connction.Execute("INSERT INTO products (Name, Price, CategoryID) " +
                "VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        public void DeleteProduct(int productID)
        {
            _connction.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID = productID });
            _connction.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID = productID });
            _connction.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connction.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProduct(int productID, string updatedName)
        {
            _connction.Execute("UPDATE products SET Name = @updatedName WHERE productID = @productID = @productID;",
                new { productID = productID, updatedName = updatedName }); 
        }
    }
}

