using lr6_3_.Interfaces;
using lr6_3_.Models;

namespace lr6_3_.Services
{
    public class HouseData : IHouseData
    {
        private List<House> _houseList;

        public HouseData()
        {
            _houseList = new List<House>
        {
            new House { Id = 1, Adress = "Komandarma Uborevicha Ul., bld. 20, appt. 193", Price = 25000 },
            new House { Id = 2, Adress = "Spartakovskiy Per., bld. 57, appt. 2", Price = 54000 },
            new House { Id = 3, Adress = "Glushko Akademika Pr., bld. 19/1, appt. 2", Price = 43000 },
            new House { Id = 4, Adress = "SHevchenko B-R, bld. 77, appt. 9", Price = 12000 },
            new House { Id = 5, Adress = "Bozhenka Vul., bld. 100, appt. 27", Price = 39000 },
            new House { Id = 6, Adress = "Orna Vul., bld. 3, appt. 1", Price = 80000 },
            new House { Id = 7, Adress = "Nikolaevskoe SHosse, bld. 14, appt. 57", Price = 98000 },
            new House { Id = 8, Adress = "Arkhitektorov Ul., bld. 19, appt. 26", Price = 60000 },
            new House { Id = 9, Adress = "Srednyaya Ul., bld. 9, appt. 52", Price = 76000 },
            new House { Id = 10, Adress = "Sverdlova Ul., bld. 75, appt. 1", Price = 55000 },
        };
        }

        public Task<List<House>> GetAllAsync()
        {
            return Task.FromResult(_houseList);
        }

        public Task<House> AddAsync(House model)
        {
            model.Id = _houseList.Max(x => x.Id) + 1;
            _houseList.Add(model);
            return Task.FromResult(model);
        }

        public Task<House> UpdateAsync(int id, House model)
        {
            var item = _houseList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Adress = model.Adress;
                item.Price = model.Price;
                return Task.FromResult(item);
            }
            return Task.FromResult<House>(null);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _houseList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _houseList.Remove(item);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}

