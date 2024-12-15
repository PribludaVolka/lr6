using lr6_3_.Interfaces;
using lr6_3_.Models;

namespace lr6_3_.Services
{
    public class CarData : ICarData
    {
        private List<Car> _carList;

        public CarData()
        {
            _carList = new List<Car>
        {
            new Car { Id = 1, Model = "1977 Datsun 620 King Cab", PassengerSeats = 3 },
            new Car { Id = 2, Model = "1997 Lister Storm", PassengerSeats = 1 },
            new Car { Id = 3, Model = "2016 Alfa Romeo Giulia Quadrifoglio", PassengerSeats = 3 },
            new Car { Id = 4, Model = "1997 Koenigsegg CC", PassengerSeats = 3 },
            new Car { Id = 5, Model = "1979 Talbot Sunbeam Lotus", PassengerSeats = 2 },
            new Car { Id = 6, Model = "2010 Volkswagen Polo 5-Door", PassengerSeats = 5 },
            new Car { Id = 7, Model = "2004 Pescarolo C60", PassengerSeats = 1 },
            new Car { Id = 8, Model = "2007 Hyundai Tucson", PassengerSeats = 3 },
            new Car { Id = 9, Model = "2015 MAN TGX", PassengerSeats = 2 },
            new Car { Id = 10, Model = "2018 Seat Ateca FR", PassengerSeats = 7 },
        };
        }

        public Task<List<Car>> GetAllAsync()
        {
            return Task.FromResult(_carList);
        }

        public Task<Car> AddAsync(Car model)
        {
            model.Id = _carList.Max(x => x.Id) + 1;
            _carList.Add(model);
            return Task.FromResult(model);
        }

        public Task<Car> UpdateAsync(int id, Car model)
        {
            var item = _carList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Model = model.Model;
                item.PassengerSeats = model.PassengerSeats;
                return Task.FromResult(item);
            }
            return Task.FromResult<Car>(null);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _carList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _carList.Remove(item);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}

