using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
    public interface IRestarauntService
    {
        public Task<string> CreateAsync(string name,RestarauntCategory restarauntCategory);
        public Task<string> UpdateAsync(int id,string name);
        public Task<string> RemoveAsync(int id);
        public Task <Restaraunt> GetAsync(int id);
        public Task <List<Restaraunt>> GetAllAsync();
    
        


    }
}
