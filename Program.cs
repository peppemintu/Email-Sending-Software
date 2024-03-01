namespace MailSender;

class Program
{
    static void Main(string[] args)
    {
        Send();
    }

    public static void Send()
    {
        Console.Write("Enter receiver's email: ");
        string receiverEmail = Console.ReadLine();

        Console.Write("Enter the subject of the mail: ");
        string subject = Console.ReadLine();

        string pathToHtmlFrom = "/Users/greendal/Projects/MailSender/Form.html";
        string text = File.ReadAllText(pathToHtmlFrom);

        /*Console.Write("Enter text of the mail: ");
        string text = Console.ReadLine();*/

        EmailService emailService = new EmailService();
        emailService.SendEmail(receiverEmail, subject, text);
    }
}

