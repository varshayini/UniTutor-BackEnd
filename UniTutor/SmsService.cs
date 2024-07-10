//using System;
//using System.Net;
//using System.Net.Mail;
//using System.Threading.Tasks;
//using UniTutor;

//public class EmailSmsService : ISmsService
//{
//    public async Task SendSmsAsync(string phoneNumber, string message)
//    {
//        // Replace with actual carrier email domain
//        string gatewayAddress = GetGatewayAddressForCarrier("Verizon"); // Example: Verizon carrier

//        // Construct the email address
//        string toEmail = phoneNumber + "@" + gatewayAddress;

//        // Set up the SMTP client
//        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); // Replace with your SMTP server and port

//        // Enable SSL/TLS
//        client.EnableSsl = true;

//        // Set credentials
//        client.Credentials = new NetworkCredential("ketheeswaranabivarsan@gmail.com", "njxf adgu lccs bljq"); // Replace with your Gmail credentials

//        // Create the email message
//        MailMessage mailMessage = new MailMessage();
//        mailMessage.From = new MailAddress("ketheeswaranabivarsan@gmail.com"); // Replace with your email address
//        mailMessage.To.Add(toEmail);
//        mailMessage.Subject = ""; // Subject can usually be left blank
//        mailMessage.Body = message;

//        try
//        {
//            await client.SendMailAsync(mailMessage);
//            Console.WriteLine("SMS sent successfully via Email-to-SMS gateway.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Failed to send SMS: {ex.Message}");
//            throw;
//        }
//        finally
//        {
//            // Dispose the SmtpClient to release resources
//            client.Dispose();
//        }
//    }

//    private string GetGatewayAddressForCarrier(string carrier)
//    {
//        switch (carrier.ToLower())
//        {
//            case "verizon":
//                return "vtext.com"; // Verizon's email-to-SMS gateway domain
//            // Add cases for other carriers as needed
//            default:
//                throw new ArgumentException("Unsupported carrier.");
//        }
//    }
//}
