using lr6_3_.Interfaces;
using lr6_3_.Models;

namespace lr6_3_.Services
{
    public class PersonData : IPersonData
    {
        private List<Person> _personList;

        public PersonData()
        {
            _personList = new List<Person>
        {
            new Person { Id = 1, Name = "Oleg", Age = 16 },
            new Person { Id = 2, Name = "Nikita", Age = 23 },
            new Person { Id = 3, Name = "Stepan", Age = 43 },
            new Person { Id = 4, Name = "Diana", Age = 31 },
            new Person { Id = 5, Name = "Marina", Age = 33 },
            new Person { Id = 6, Name = "Gosha", Age = 25 },
            new Person { Id = 7, Name = "Misha", Age = 27 },
            new Person { Id = 8, Name = "Elena", Age = 19 },
            new Person { Id = 9, Name = "Petya", Age = 38 },
            new Person { Id = 10, Name = "Ira", Age = 65 },
        };
        }

        public Task<List<Person>> GetAllAsync()
        {
            return Task.FromResult(_personList);
        }

        public Task<Person> AddAsync(Person model)
        {
            model.Id = _personList.Max(x => x.Id) + 1;
            _personList.Add(model);
            return Task.FromResult(model);
        }

        public Task<Person> UpdateAsync(int id, Person model)
        {
            var item = _personList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Name = model.Name;
                item.Age = model.Age;
                return Task.FromResult(item);
            }
            return Task.FromResult<Person>(null);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _personList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _personList.Remove(item);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
