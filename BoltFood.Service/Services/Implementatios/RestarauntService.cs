using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Core.Models.Repostories.RestarauntRepostory;
using BoltFood.Service.Services.Interfaces;
using BoltFoodData.Repostories.RestarauntRepostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementatios
{
    public class RestarauntService : IRestarauntService 
    {
        private readonly IRestarauntRepostory _restarauntRepository = new restarauntRepostory();

        public async Task<string> CreateAsync(string name,RestarauntCategory restarauntCategory)
        {
       

            Restaraunt restaraunt = new Restaraunt(name,restarauntCategory);

            await _restarauntRepository.AddAsync(restaraunt);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Created";
        }

        public async Task<List<Restaraunt>> GetAllAsync()
        {
            return await _restarauntRepository.GetAllAsync();
        }

        public async Task<Restaraunt> GetAsync(int id)
        {
            Restaraunt restaraunt = await _restarauntRepository.GetAsync(x=> x.Id == id);   

            if (restaraunt== null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found");
                return null;
            }
            return restaraunt;
        }

        public async Task<string> RemoveAsync(int id)
        {
            Restaraunt restaraunt = await _restarauntRepository.GetAsync(x => x.Id == id);

            if (restaraunt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found");
                return null;
            }
            await _restarauntRepository.RemoveAsync(restaraunt);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Removed";
        }

        public async Task<string> UpdateAsync(int id,string name)
        {
            Restaraunt restaraunt =  await _restarauntRepository.GetAsync(x=>x.Id == id);   

            if (restaraunt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found");
                return null;
            }
            restaraunt.Name = name;

            await _restarauntRepository.UpdateAsync(restaraunt);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Updated";
        }
    }
}
