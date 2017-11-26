using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Models
{
    public class Reservation : IStoreable
    {

        public Reservation ()
        {
            Id = null;
        }

        public IComparable Id { get; set; }

        public string Firstnanme { get; set; }

        public string Lastname { get; set; }
        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public string DepatureCity { get; set; }
        public string DestinationCity { get; set; }
    }
}
