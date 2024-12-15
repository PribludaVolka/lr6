using lr6_3_.Models;
using System;

namespace lr6_3_.Interfaces
{
    public interface IPersonData
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> AddAsync(Person model);
        Task<Person> UpdateAsync(int id, Person model);
        Task<bool> DeleteAsync(int id);
    }
}
