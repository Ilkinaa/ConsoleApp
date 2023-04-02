using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoltFood.Service.Services.Implementatios
{
    public class MenuService : IMenuService
    {
        private readonly IRestarauntService _restarauntService = new RestarauntService();
        private readonly IProductService _productService = new ProductService();
        public async Task ShowMenuAsync()
        {

            Show();
            int.TryParse(Console.ReadLine(), out int result);
            while (result != 0)
            {
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        await CreateRestaraunt();
                        break;
                    case 2:
                        Console.Clear();
                        await ShowAllRestaraunt();
                        break;
                    case 3:
                        Console.Clear();
                        await GetRestarauntById();
                        break;
                    case 4:
                        Console.Clear();
                        await UpdateRestaraunt();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveRestaraunt();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateProduct();
                        break;
                    case 7:
                        Console.Clear();

                        await ShowAllProducts();
                        break;
                    case 8:
                        Console.Clear();

                        await GetProductById();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateProduct();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveProduct();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please choose valid option");
                        break;

                }
                Console.ForegroundColor = ConsoleColor.White;

                Show();
                int.TryParse(Console.ReadLine(), out result);
            }
        }

        private void Show()
        {
            Console.WriteLine("1.Create Restaraunt");
            Console.WriteLine("2.Show All Restaraunt");
            Console.WriteLine("3.Get Restaraunt By Id");
            Console.WriteLine("4.Update Restaraunt");
            Console.WriteLine("5.Remove Restaraunt");
            Console.WriteLine("6.Create Product");
            Console.WriteLine("7.Show All Product");
            Console.WriteLine("8.Get Product By Id");
            Console.WriteLine("9.Update Product");
            Console.WriteLine("10.Remove Product");

        }
        private async Task CreateRestaraunt()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            await Console.Out.WriteAsync("Name: ");
            string Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Ad elave ele qaqa!!!");
                return;
            }


            Console.WriteLine("Choose Restaraunt Category :");
          

            var Enums = Enum.GetValues(typeof(RestarauntCategory));
            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int restarauntCategory);

            try
            {
                Enums.GetValue(restarauntCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("RestarauntCategory is not valid");
                return;
            }
            string message = await _restarauntService.CreateAsync(Name,(RestarauntCategory)restarauntCategory);

            Console.WriteLine(message);
        }
        private async Task ShowAllRestaraunt()
        {
            List<Restaraunt> restaraunts = await _restarauntService.GetAllAsync();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in restaraunts)
            {
                Console.WriteLine($"Id:{item.Id} Name: {item.Name}  RestorauntCategory: {item.restarauntcategory}");
            }
        }
        private async Task GetRestarauntById()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter restaraunt Id");
            int.TryParse(Console.ReadLine(), out int id);
            Restaraunt restaraunt = await _restarauntService.GetAsync(id);
            Console.WriteLine($"Id:{restaraunt.Id} Name: {restaraunt.Name} RestarauntCatecory: {restaraunt.restarauntcategory}"); 
        }

        private async Task UpdateRestaraunt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Add Restaraunt Id");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("Enter Name");
            string Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Ad elave ele qaqa!!!");
                return;
            }


            string message = await _restarauntService.UpdateAsync(id,Name);
            Console.WriteLine(message);
        }
        private async Task RemoveRestaraunt()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Add Group Id");

            int.TryParse(Console.ReadLine(), out int id);

            string message = await _restarauntService.RemoveAsync(id);
            Console.WriteLine(message);
        }

        private async Task CreateProduct()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enter Restoraunt Id");
            int RestarauntId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Ad elave ele qaqa!!!");
                return;
            }


            Console.WriteLine("Enter price");

            int.TryParse(Console.ReadLine(), out int price);


            Console.WriteLine("Choose Product Category :");


            var Enums = Enum.GetValues(typeof(ProductCategory));
            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int producttCategory);

            try
            {
                Enums.GetValue(producttCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("RestarauntCategory is not valid");
                return;
            }

            

            string message = await _productService.CreateAsync(Name,price, RestarauntId,(ProductCategory)producttCategory);

            Console.WriteLine(message);
        }

        private async Task ShowAllProducts()
        {
            List<Product> products = await _productService.GetAllAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in products)
            {
                Console.WriteLine($"Id:{item.Id} Name: {item.Name} ProductCatecory: {item.productCategory} RestorauntName: {item.Restaraunt.Name}");
            }

        }

        private async Task GetProductById()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter product Id");
            int.TryParse(Console.ReadLine(), out int id);
            Product product = await _productService.GetAsync(id);
            Console.WriteLine($"Id:{product.Id} Name: {product.Name} ProductCatecory: {product.productCategory} RestoranName: {product.Restaraunt.Name}"); //productun name price categori goster
        }

        private async Task UpdateProduct()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter Id");

            int.TryParse(Console.ReadLine(), out int Id);
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Enter Name");
            string Name= Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Ad elave ele qaqa!!!");
                return;
            }

            Console.WriteLine("Enter Price");
            int.TryParse(Console.ReadLine(), out int price);




            string message = await _productService.UpdateAsync(Id, Name, price);
            Console.WriteLine(message);
        }

        private async Task RemoveProduct()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" Enter Id");

            int.TryParse(Console.ReadLine(), out int id);
            string message = await _productService.RemoveAsync(id);
            Console.WriteLine(message);
        }
    }
}

