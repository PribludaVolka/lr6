using lr6_3_.Models;
using System;
using System.Runtime.ConstrainedExecution;

namespace lr6_3_.Interfaces
{
    public interface ICarData
    {
        Task<List<Car>> GetAllAsync();
        Task<Car> AddAsync(Car model);
        Task<Car> UpdateAsync(int id, Car model);
        Task<bool> DeleteAsync(int id);
    }
}
