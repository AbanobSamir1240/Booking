using System;
using System.Globalization;
using System.Net.Mail;
using System.Net.Mime;
using GpBooking.Models;

namespace GpBooking.Services
{
    public static class MailService
    {
        public static bool SendMail(string to, string subject, string body)
        {
            bool result = true;
            try
            {

                var client = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Host = ApplicationService.ReadFromWebConfig("Host"),
                    Port = int.Parse(ApplicationService.ReadFromWebConfig("Port"))
                };

                // setup Smtp authentication
                var credentials =
                    new System.Net.NetworkCredential(ApplicationService.ReadFromWebConfig("username"),
                        ApplicationService.ReadFromWebConfig("password"));
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                var msg = new MailMessage
                {
                    From = new MailAddress(ApplicationService.ReadFromWebConfig("username")),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = string.Format($"<!DOCTYPE html><html><head></head><body>{body}</body></html>")
                };
                msg.To.Add(new MailAddress(to));

                client.Send(msg);
            }
            catch (Exception exception)
            {
                result = false;
            }

            return result;
        }

        public static string HandleOne(string mail, HotelReservations hotelReservation)
        {
            mail = mail.Replace("-user-", hotelReservation.ApplicationUser.Name);
            mail = mail.Replace("-TypeName-", hotelReservation.HotelRooms.HotelRoomType.TypeName);
            mail = mail.Replace("-Price-", hotelReservation.HotelRooms.Price.ToString());
            mail = mail.Replace("-HotelName-", hotelReservation.HotelRooms.Hotel.Name);
            mail = mail.Replace("-Address-", hotelReservation.HotelRooms.Hotel.Address);
            mail = mail.Replace("-Tel1-", hotelReservation.HotelRooms.Hotel.Tel1);
            mail = mail.Replace("-ReservationDate-", hotelReservation.ReservationDate.ToString());
            mail = mail.Replace("-StartDate-", hotelReservation.StartDate.ToString());
            mail = mail.Replace("-EndDate-", hotelReservation.EndDate.ToString());
            mail = mail.Replace("-PaymentType-", hotelReservation.PaymentType.ToString());
            return mail;
        }

        public static string HandleTwo(string mail, ClubReservations clubReservations)
        {
            mail = mail.Replace("-user-", clubReservations.ApplicationUser.Name);
            mail = mail.Replace("-ClubName-", clubReservations.Club.Name);
            mail = mail.Replace("-Address-", clubReservations.Club.Address);
            mail = mail.Replace("-Tel1-", clubReservations.Club.Tel1);
            mail = mail.Replace("-ReservationDate-", clubReservations.ReservationDate.ToString());
            mail = mail.Replace("-StartDate-", clubReservations.StartDate.ToString());
            mail = mail.Replace("-EndDate-", clubReservations.EndDate.ToString());
            mail = mail.Replace("-PaymentType-", clubReservations.PaymentType.ToString());
            return mail;
        }

        public static string HandleThree(string mail, RestaurantReservations hotelReservations)
        {
            mail = mail.Replace("-user-", hotelReservations.ApplicationUser.Name);
            mail = mail.Replace("-Name-", hotelReservations.Restaurant.Name);
            mail = mail.Replace("-Address-", hotelReservations.Restaurant.Address);
            mail = mail.Replace("-Tel1-", hotelReservations.Restaurant.Tel1);
            mail = mail.Replace("-ReservationDate-", hotelReservations.ReservationDate.ToString());
            mail = mail.Replace("-Date-", hotelReservations.Date.ToString());
            mail = mail.Replace("-Tabel-", hotelReservations.NumberOfTable.ToString());
            mail = mail.Replace("-PaymentType-", hotelReservations.PaymentType.ToString());
            return mail;
        }
    }
}
