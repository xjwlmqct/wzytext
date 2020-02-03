using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Models
{
    public class ProductRepository : IProductRepository
    {

        private List<Product> products = new List<Product>();

        private int _nextId = 1;
        public ProductRepository()
        {
            Add(new Product
            {
                Name = "西红柿",
                Category = "水果",
                Price = 6.00M
            });
            Add(new Product { Name = "Yo_yo", Category = "玩具", Price = 13.84M });
            Add(new Product { Name = "Hammer", Category = "硬件", Price = 245M });
        }
        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;

        }

        public Product Get(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentException("item");
            }
            int id = products.FindIndex(p => p.Id == item.Id);
            if(id==-1)
            {
                return false;
            }
            products.RemoveAt(id);
            products.Add(item);
            return true;
        }
    }
}