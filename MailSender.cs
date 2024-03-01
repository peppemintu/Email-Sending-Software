using MailKit.Net.Smtp;
using MimeKit;

namespace MailSender;

public class EmailService
{
	const string senderEmail = "tester.bob.1468@gmail.com";
	const string senderPassword = "gjdi qjsn zauc bjnd";

	public EmailService() { }

	public void SendEmail(string receiverEmail, string subject,
	 					  string emailText)
	{
		MimeMessage emailMessage = new MimeMessage();

		emailMessage.From.Add(new MailboxAddress("Sender", senderEmail));
		emailMessage.To.Add(MailboxAddress.Parse(receiverEmail));
		emailMessage.Subject = subject;
		emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
		{
			Text = emailText
		};

		using (var client = new SmtpClient())
		{
			string smtpServer = "smtp.gmail.com";
			int serverPort = 465;
			bool sslEnabled = true;

			try
			{
				client.Connect(smtpServer, serverPort, sslEnabled);
				client.Authenticate(senderEmail, senderPassword);
				var serverMessage = client.Send(emailMessage);
				Console.WriteLine(serverMessage);
			}
			catch (Exception e)
			{
				Console.Write(e.Message);
			}
			finally
			{
				client.Disconnect(true);
			}
		}
	}
}

