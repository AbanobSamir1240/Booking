﻿using System;
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

                //client.Send(msg);
            }
            catch (Exception exception)
            {
                result = false;
            }

            return result;
        }


    }
}