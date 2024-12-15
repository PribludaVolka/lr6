using lr6_3_.Models;
using System;

namespace lr6_3_.Interfaces
{
    public interface IHouseData
    {
        Task<List<House>> GetAllAsync();
        Task<House> AddAsync(House model);
        Task<House> UpdateAsync(int id, House model);
        Task<bool> DeleteAsync(int id);
    }
}
