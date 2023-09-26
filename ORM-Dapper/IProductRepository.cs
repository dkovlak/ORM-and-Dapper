using System;
namespace ORM_Dapper
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public void CreatProduct(string name, double price, int categotyID);

        public void UpdateProduct(int productID, string updatedName);

        public void DeleteProduct(int productID);
    }

}

