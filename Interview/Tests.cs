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

            int expectedResult = 0;
            int actualResult = reservationRepository.All().Count();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void All_Should_Return_3_Items()
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

            reservation = new Reservation
            {
                Firstnanme = "James",
                Lastname = "Bond",
                DepartureDate = new DateTime(2017, 11, 7),
                ReturnDate = new DateTime(2017, 11, 21),
                DepatureCity = "London",
                DestinationCity = "Paris"
            };
            reservationRepository.Save(reservation);

            reservation = new Reservation
            {
                Firstnanme = "Jane",
                Lastname = "Doe",
                DepartureDate = new DateTime(2017, 12, 1),
                ReturnDate = new DateTime(2017, 12, 8),
                DepatureCity = "Manchester",
                DestinationCity = "Rome"
            };
            reservationRepository.Save(reservation);

            int expectedResult = 3;
            int actualResult = reservationRepository.All().Count();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void Delete_Should_Delete_Reservation_With_Id_1()
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

            reservationRepository.Delete(1);

            int expectedResult = 0;
            int actualResult = reservationRepository.All().Count();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void Delete_Should_Fail_Delete_Of_Reservation_With_Id_2()
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            Assert.Throws<System.Exception>(() => reservationRepository.Delete(2));
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

            var savedReservation = reservationRepository.FindById(1);

            Assert.AreEqual(reservation,savedReservation);

        }

        [Test]
        public void Save_Should_Save_Update_Reservation_With_Id_1 ()
        {


            ReservationRepository reservationRepository = new ReservationRepository();
            string expectedResult = "Paris";

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

            var updatedReservation = reservationRepository.FindById(1);

            Assert.AreEqual(expectedResult, updatedReservation.DestinationCity);

        }


        [Test]
        public void Save_Should_Fail_Save_Reservation_With_Id_3()
        {
            ReservationRepository reservationRepository = new ReservationRepository();

            Reservation reservation = new Reservation
            {
                Id = 3,
                Firstnanme = "John",
                Lastname = "Smith",
                DepartureDate = new DateTime(2017, 11, 1),
                ReturnDate = new DateTime(2017, 11, 14),
                DepatureCity = "London",
                DestinationCity = "New York"
            };

            Assert.Throws<Exception>(() => reservationRepository.Save(reservation));

        }



    }
}