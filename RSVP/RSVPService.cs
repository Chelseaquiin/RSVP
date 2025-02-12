using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;

namespace RSVP
{
    public class RSVPService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;

        public RSVPService(AppDbContext dbContext, IConfiguration config)
        {
                _dbContext = dbContext;
                _config = config;   
        }

        public async Task<BaseResponse> UserConfirmation(UserRequest request)
        {
            try
            {
                if (request == null) 
                {
                    return new BaseResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        Message = "Request cannot be null"
                    };
                }

                var existingUser = await _dbContext.Users.FirstOrDefaultAsync(s => s.Email == request.Email);

                if (existingUser != null) 
                {
                    return new BaseResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        Message = "User already exists"
                    };
                }

                User newUser = new()
                {
                    GuestNames = request.GuestNames,
                    ComingWithAGuest = request.ComingWithAGuest,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    NumberOfGuests = request.NumberOfGuests,
                    LastName = request.LastName,
                    Phone = request.Phone,
                    WillAttend = request.WillAttend,
                    
                };

                 _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "User details recorded successfully",
                    UserId = newUser.Id
                };
            }
            catch(Exception ex)  
            {
                return new BaseResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Something went wrong"
                };
            }

        }

        public async Task<BaseResponse> HotelReservation(HotelRequest request)
        {
            try
            {
                if (request == null) 
                {
                    return new BaseResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        Message = "Request cannot be null"
                    };
                }
                if (!request.ReserveAHotel)
                {
                    return new BaseResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Message = "No hotel reservation for user"
                    };
                }

                HotelReservation hotel = new()
                {
                    HotelName = request.HotelName,
                    NumberOfDays = request.NumberOfDays,
                    UserId = request.UserId,
                };

                _dbContext.HotelReservations.Add(hotel);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = $"{request.HotelName} has been reserved"
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Something went wrong"
                };
            }

        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(
                    _config["EmailSetting:SenderName"],
                    _config["EmailSetting:SenderEmail"]
                ));
                email.To.Add(new MailboxAddress("", toEmail));
                email.Subject = subject;

                email.Body = new TextPart("html") { Text = body };

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                await smtp.ConnectAsync(_config["EmailSetting:SmtpServer"],
                                        int.Parse(_config["EmailSetting:SmtpPort"]),
                                        MailKit.Security.SecureSocketOptions.StartTls);

                smtp.AuthenticationMechanisms.Remove("XOAUTH2");

                await smtp.AuthenticateAsync(_config["EmailSettings:SenderEmail"],
                                             _config["EmailSettings:SenderPassword"]);

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
