using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private List<Plane> _planes;

        public List<Plane> Planes 
        { 
            get {return _planes;} 
        }

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public IEnumerable<PassengerPlane> GetPassengersPlanes()
        {
            return _planes.Where(t => t.GetType() == typeof(PassengerPlane)).
            Cast<PassengerPlane>().ToList();
        }

        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.Where(t => t.GetType() == typeof(MilitaryPlane)).
                           Cast<MilitaryPlane>().ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes()
                   .Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes()
                   .Where(plane => plane.Type == MilitaryTypes.Transport).ToList();

        }
        public Airport SortPlanesByMaxFlightDistance()
        {
            return new Airport(_planes.OrderBy(w => w.MaxFlightDistance).ToList());
        }
        public Airport SortPlanesByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(w => w.MaxSpeed).ToList());
        }

        public Airport SortPlanesByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(w => w.MaxLoadCapacity).ToList());
        }      

        public override string ToString()
        {
            return "Airport{" + "planes=" + string.Join(", ", _planes.Select(x => x.Model)) + '}';
        } 
    }
}
