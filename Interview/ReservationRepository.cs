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
            throw new NotImplementedException();
        }
        public void Delete(IComparable id)
        {
            throw new NotImplementedException();
        }
        public void Save(Reservation item)
        {
            throw new NotImplementedException();
        }
        public Reservation FindById(IComparable id)
        {
            throw new NotImplementedException();
        }


    }
}
