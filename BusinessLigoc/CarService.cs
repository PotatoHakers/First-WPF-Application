
using Model;

namespace BusinessLigoc
{

        public class CarService
        {
            ApplicationContext _db;

            public CarService()
            {
                _db = new ApplicationContext();
            }

            public void Create(Car model)
            {
                _db.Car.Add(model);
                _db.SaveChanges();
            }
            public IEnumerable<Car> Get()
            {
                return _db.Car.ToList();
            }
            public void Delete(Car model)
            {
                _db.Car.Remove(model);
                _db.SaveChanges();
            }
            public void Update(Car model)
            {
                _db.Car.Update(model);
                _db.SaveChanges();
            }
        }
    }


