using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.ThirdMethodRepository
{
    class VehicleTMRepository : IVehicleDbManager
    {
        public static MotocycleTMRepository motocycleRepository = new MotocycleTMRepository();
        public static CarTMRepository carRepository = new CarTMRepository();
        public static BusTMRepository busRepository = new BusTMRepository();
        public List<Vehicle> Fetch()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.AddRange(motocycleRepository.Fetch());
            vehicles.AddRange(carRepository.Fetch());
            vehicles.AddRange(busRepository.Fetch());

            return vehicles;
        }

        public void Delete(Vehicle t)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle t)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle t)
        {
            throw new NotImplementedException();
        }
    }
}
