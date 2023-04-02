using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Core.Models.Repostories.RestarauntRepostory;
using BoltFood.Service.Services.Interfaces;
using BoltFoodData.Repostories.RestarauntRepostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementatios
{
    public class ProductService : IProductService
    {
        private readonly IRestarauntRepostory _restarauntRepository = new restarauntRepostory();
        public async Task<string> CreateAsync(string name, double price, int RestaraundId, ProductCategory productCategory)
        {
            Restaraunt restaraunt = await _restarauntRepository.GetAsync(x => x.Id == RestaraundId);

            if (restaraunt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaraunt is not valid");
                return null;

            }

            Product product = new Product(name, price, restaraunt, productCategory);
            restaraunt.products.Add(product);
            return "Succesfuly Created";
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Restaraunt> restaraunts = await _restarauntRepository.GetAllAsync();

            List<Product> products = new List<Product>();

            foreach (Restaraunt restaraunt in restaraunts)
            {
                products.AddRange(restaraunt.products);
            }
            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            List<Restaraunt> restaraunt = await _restarauntRepository.GetAllAsync();

            foreach (var item in restaraunt)
            {
                Product product = item.products.Find(x => x.Id == id);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<string> RemoveAsync(int id)
        {
            List<Restaraunt> restaraunt = await _restarauntRepository.GetAllAsync();

            foreach (var item in restaraunt)
            {
                Product product = item.products.Find(x => x.Id == id);
                if (product != null)
                {
                    item.products.Remove(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Succesfuly Removed";
                }
            }
            return "Qaqa sile bilmedim balamin cani";
        }
        public async Task<string> UpdateAsync(int id, string name, double price)
        {
            List<Restaraunt> restaraunt = await _restarauntRepository.GetAllAsync();

            foreach (var item in restaraunt) 
            {
                Product product = item.products.Find(x => x.Id == id);
                if (product != null)
                {
                    product.Name = name;
                    product.Id = id; 
                    product.Price = price;
                    product.CreatedDate= DateTime.Now;
                    product.UpdatedDate = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Green;

                    return "Succesfuly Updated";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;

            return "Product is not found";
        }
    }
}

