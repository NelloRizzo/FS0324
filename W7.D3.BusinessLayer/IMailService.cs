namespace W7.D3.BusinessLayer
{
    public interface IMailService
    {
        void SendMail(string to, string subject, string body);
    }
}
