using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interview.Models;

namespace Interview
{
    public class ReservationRepository : IRepository<Reservation>
    {
        public ReservationRepository ()
        {
            _inMemoryReservation = new List<Reservation>();
        }

        private List<Reservation> _inMemoryReservation = new List<Reservation>();

        public IEnumerable<Reservation> All()
        {
            return _inMemoryReservation;
        }
        public void Delete(IComparable id)
        {
            var removeReservation = FindById(id);

            if (removeReservation == null)
                throw new System.Exception();

            _inMemoryReservation.Remove(removeReservation);
        }
        public void Save(Reservation item)
        {
            if (item.Id == null)
            {
                item.Id = _inMemoryReservation.Count + 1;
                _inMemoryReservation.Add(item);
            }

            var savedReservation = FindById(item.Id);

            if (savedReservation == null)
                throw new Exception();

            savedReservation.Firstnanme = item.Firstnanme;
            savedReservation.Lastname = item.Lastname;
            savedReservation.DepartureDate = item.DepartureDate;
            savedReservation.DepatureCity = item.DepatureCity;
            savedReservation.DestinationCity = item.DestinationCity;
            savedReservation.ReturnDate = item.ReturnDate;
          
        }
        public Reservation FindById(IComparable id)
        {
            var reservation = _inMemoryReservation.Find(Matches(id));
            return reservation;
        }

        private  Predicate<Reservation> Matches(IComparable id)
        {
            return i => i.Id.Equals(id);
        }



    }
}
