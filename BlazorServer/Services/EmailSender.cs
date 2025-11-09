using BlazorServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BlazorServer.Services;

/// <summary>
/// Source: https://learn.microsoft.com/en-ca/aspnet/core/security/authentication/accconfirm?view=aspnetcore-9.0&tabs=net-cli
/// </summary>
/// <param name="optionsAccessor"></param>
/// <param name="logger"></param>
public class EmailSender(
    IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger
) : IEmailSender<ApplicationUser>
{
    private readonly ILogger _logger = logger;

    public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SendGridKey))
        {
            // throw new Exception("Null SendGridKey");
            _logger.LogError("Null SendGridKey (You need a SendGrid API key to send emails)");
            return;
        }
        await Execute(Options.SendGridKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("hobbylobbyauth@gmail.com", "Hobby Lobby"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message,
        };
        msg.AddTo(new EmailAddress(toEmail));

        // Disable click tracking.
        // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        msg.SetClickTracking(false, false);
        var response = await client.SendEmailAsync(msg);
        _logger.LogInformation(
            response.IsSuccessStatusCode
                ? $"Email to {toEmail} queued successfully!"
                : $"Failure Email to {toEmail}"
        );
    }

    public Task SendConfirmationLinkAsync(
        ApplicationUser user,
        string email,
        string confirmationLink
    )
    {
        return SendEmailAsync(
            email,
            "HobbyLobby Email Confirmation",
            $"Hello {user.UserName}, here is your email confirmation link: {confirmationLink}."
        );
    }

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        return SendEmailAsync(
            email,
            "HobbyLobby Password Reset",
            $"Hello {user.UserName}, here is your password reset link: {resetLink}."
        );
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        return SendEmailAsync(
            email,
            "HobbyLobby Password Reset",
            $"Hello {user.UserName}, here is your password reset code: {resetCode}."
        );
    }
}
