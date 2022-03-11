using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp2
{
    public class Heartbeat
    {
        private readonly System.Timers.Timer _timer;

        public Heartbeat()
        {
            _timer = new System.Timers.Timer(1000*5) { AutoReset = true };
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {

            var dateAndTime = DateTime.Now;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-Visma_Library_2022-FC2B25F7-34AA-431F-81ED-0D9EBF474717;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            //string sqlStatement = $"SELECT dbo.AspNetUsers.Email FROM dbo.AspNetUsers";

            string sqlStatement = $"SELECT dbo.AspNetUsers.UserName, dbo.Reservation.DateTo FROM dbo.AspNetUsers INNER JOIN dbo.Reservation ON dbo.AspNetUsers.Id = dbo.Reservation.Email WHERE dbo.Reservation.DateTo < '{dateAndTime.ToString("yyyy - MM - dd")}'";
            //WHERE DateTo< '{dateAndTime.ToString("yyyy - MM - dd")}'

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        WriteEmail(Convert.ToString(reader.GetValue(0)));
                        Console.WriteLine(Convert.ToString(reader.GetValue(1)));

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }


        public void WriteEmail(string to)
        {


            //string to = "vilumsjurgis.lv@gmail.com"; //To address    
            string from = "vilumsjurgis.lvv@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = @"<html>
                      <body>
                      <p>Hello!</p>
                      <p>It is time to bring book back.</p>
                      <p>Sincerely,<br>-Visma</br></p>
                      </body>
                      </html>
                     ";
            message.Subject = "Friendly reminder!";
            message.Body = mailbody;
            //message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("vilumsjurgis.lvv@gmail.com", "jv1345790862LVV");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;



            try
            {

                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }



        }







    }
}
