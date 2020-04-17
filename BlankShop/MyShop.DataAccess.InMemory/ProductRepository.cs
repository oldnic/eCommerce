﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory {
    class ProductRepository {
        ObjectCache objectCache = MemoryCache.Default;
        List<Product> products;
        public ProductRepository() {
            products = objectCache["products"] as List<Product>;
            
            if (products == null) {
                products = new List<Product>();
            }
        }
        public void Commit() {
            objectCache["products"] = products;
        }
        public void Insert(Product product) {
            products.Add(product);
        }
        public void Update(Product product) {
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate != null) {
                productToUpdate = product;
            } else {
                throw new Exception("Product not found");
            }
        }
        public Product Find(string Id) {
            Product product = products.Find(p => p.Id == Id);

            if (product != null) {
                return product;
            } else {
                throw new Exception("Product not found");
            }
        }
        public IQueryable<Product> Collections() { 
            return products.AsQueryable();
        }
        public void Delete(string Id) {
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete != null) {
                products.Remove(productToDelete);
            } else {
                throw new Exception("Product not found");
            }
        }
    }
}
