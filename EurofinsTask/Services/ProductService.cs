using EurofinsTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EurofinsTask.Services
{
    public class ProductService
    {
        private EurofinsTaskContext _db;

        public ProductService()
        {
            _db = new EurofinsTaskContext();
        }

        public List<Product> GetProducts()
        {
            return _db.Products.OrderByDescending(x => x.Id).ToList();
        }

        public Product GetProduct(int id)
        {
            return _db.Products.FirstOrDefault(x => x.Id == id);
        }
        
        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }
        
        public void UpdateProduct(Product product)
        {
            var productInDb = _db.Products.FirstOrDefault(x => x.Id == product.Id);
            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.Description = product.Description;
            _db.SaveChanges();
        }
        
        public bool RemoveProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            else
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            }
        }
    }
}