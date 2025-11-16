using System.Security.Claims;
using BlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Services;

public interface IUserService
{
    ApplicationUser DefaultUser { get; }

    Task<string?> GetCurrentUserId(AuthenticationStateProvider authProvider);

    Task<ApplicationUser?> GetCurrentUser(
        AuthenticationStateProvider authProvider,
        ApplicationDbContext db
    );

    void RedirectToLogin(NavigationManager navManager);

    Task<ApplicationUser?> GetFromUsername(ApplicationDbContext db, string username);
}

public class UserService : IUserService
{
    public ApplicationUser DefaultUser =>
        new()
        {
            Country = "Earth",
            BannerURL = "banner/bg3.png",
            ProfilePictureURL = "pfp/finally.jpg",
        };

    public async Task<string?> GetCurrentUserId(AuthenticationStateProvider authProvider)
    {
        AuthenticationState authState = await authProvider.GetAuthenticationStateAsync();
        ClaimsPrincipal userClaims = authState.User;

        bool isLoggedIn = userClaims?.Identity?.IsAuthenticated == true;
        if (!isLoggedIn)
        {
            return null;
        }

        string? userId = userClaims!.FindFirstValue(ClaimTypes.NameIdentifier);

        return userId;
    }

    public async Task<ApplicationUser?> GetCurrentUser(
        AuthenticationStateProvider authProvider,
        ApplicationDbContext db
    )
    {
        string? userId = await GetCurrentUserId(authProvider);
        if (userId is null)
        {
            return null;
        }

        return await db.Users.FindAsync(userId);
    }

    public void RedirectToLogin(NavigationManager navManager)
    {
        navManager.NavigateTo($"Account/Login?returnUrl={Uri.EscapeDataString(navManager.Uri)}");
    }

    public async Task<ApplicationUser?> GetFromUsername(ApplicationDbContext db, string username)
    {
        return await db
            .Users.Where(u => u.UserName != null && u.UserName.ToLower().Equals(username.ToLower()))
            .FirstAsync();
    }
}
