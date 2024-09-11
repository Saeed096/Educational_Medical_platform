namespace Educational_Medical_platform.Helpers
{
    public interface IEmailService
    {
        Task SendEmailAsync(string mailTo, string subject, string body);
    }
}
