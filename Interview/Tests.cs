using System.Diagnostics;
using System.Linq;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using Interview.Models;

namespace Interview
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void All_Should_Return_No_Items()
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            reservationRepository.All();
        }

        [Test]
        public void All_Should_Return_3_Items()
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            reservationRepository.All();
        }

        [Test]
        public void Delete_Should_Delete_Reservation_With_Id_1()
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            reservationRepository.Delete(1);
        }

        [Test]
        public void Delete_Should_Fail_Reservation_With_Id_2()
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            reservationRepository.Delete(1);
        }

        [Test]
        public void Save_Should_Save_New_Reservation()
        {
            ReservationRepository reservationRepository = new ReservationRepository();

            Reservation reservation = new Reservation
            {
                Firstnanme = "John",
                Lastname = "Smith",
                DepartureDate = new DateTime(2017, 11, 1),
                ReturnDate = new DateTime(2017, 11, 14),
                DepatureCity = "London",
                DestinationCity = "New York"
            };

            reservationRepository.Save(reservation);
        }

        [Test]
        public void Save_Should_Save_Update_Reservation_With_Id_1 ()
        {
            ReservationRepository reservationRepository = new ReservationRepository();

            Reservation reservation = new Reservation
            {
                Firstnanme = "John",
                Lastname = "Smith",
                DepartureDate = new DateTime(2017, 11, 1),
                ReturnDate = new DateTime(2017, 11, 14),
                DepatureCity = "London",
                DestinationCity = "New York"
            };

            reservationRepository.Save(reservation);

            var savedReservation = reservationRepository.FindById(1);

            savedReservation.DestinationCity = "Paris";

            reservationRepository.Save(savedReservation);

        }


        [Test]
        public void Save_Should_Fail_Save_Reservation_With_Id_3()
        {
            ReservationRepository reservationRepository = new ReservationRepository();

            Reservation reservation = new Reservation
            {
                Firstnanme = "John",
                Lastname = "Smith",
                DepartureDate = new DateTime(2017, 11, 1),
                ReturnDate = new DateTime(2017, 11, 14),
                DepatureCity = "London",
                DestinationCity = "New York"
            };

            reservationRepository.Save(reservation);

            var savedReservation = reservationRepository.FindById(1);

            savedReservation.DestinationCity = "Paris";

            reservationRepository.Save(savedReservation);

        }



    }
}