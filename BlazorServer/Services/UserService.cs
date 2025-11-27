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

    void RedirectToBcitEmail(NavigationManager navManager);

    Task<ApplicationUser?> GetFromUsername(ApplicationDbContext db, string username);

    Task<ApplicationUser?> GetFromId(ApplicationDbContext db, string id);

    Task<List<ApplicationUser>> GetAllUsers(ApplicationDbContext db);

    Task<float> GetMatchPercentage(ApplicationDbContext db, AuthenticationStateProvider authProvider, ApplicationUser otherUser);

    Task<List<float>> GetMatchPercentages(ApplicationDbContext db, AuthenticationStateProvider authProvider, List<ApplicationUser> otherUsers);
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

    public async Task<List<ApplicationUser>> GetAllUsers(ApplicationDbContext db)
    {
        return db.Users
            .Include(u => u.Hobbies).ToList<ApplicationUser>();
    }

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

        return await db.Users.Include(u => u.Hobbies).FirstOrDefaultAsync(u => u.Id == userId);
    }

    public void RedirectToLogin(NavigationManager navManager)
    {
        navManager.NavigateTo($"Account/Login?returnUrl={Uri.EscapeDataString(navManager.Uri)}");
    }

    public void RedirectToBcitEmail(NavigationManager navManager)
    {
        navManager.NavigateTo($"Account/Manage/OrganizationalEmail");
    }

    public async Task<ApplicationUser?> GetFromUsername(ApplicationDbContext db, string username)
    {
        return await db
            .Users
            .Include(u => u.Hobbies)
            .Where(u => u.UserName != null && u.UserName.ToLower().Equals(username.ToLower()))
            .FirstAsync();
    }

    public async Task<ApplicationUser?> GetFromId(ApplicationDbContext db, string id)
    {
        return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<float> GetMatchPercentage(ApplicationDbContext db, AuthenticationStateProvider authProvider, ApplicationUser otherUser)
    {
        var user = await GetCurrentUser(authProvider, db);
        if (user?.Hobbies == null || user?.Hobbies.Count == 0 || user == null || otherUser == null || otherUser.Hobbies == null)
        {
            return 0;
        }
        else
        {
            return 100 * user.Hobbies.Intersect(otherUser.Hobbies).ToList<Hobby>().Count / user.Hobbies.Count;
        }

    }

    public async Task<List<float>> GetMatchPercentages(ApplicationDbContext db, AuthenticationStateProvider authProvider, List<ApplicationUser> otherUsers)
    {
        List<float> percentages = new List<float>();
        var user = await GetCurrentUser(authProvider, db);

        for (int i = 0; i < otherUsers.Count; i++)
        {
            var otherUser = otherUsers[i];
            if (user?.Hobbies == null || user?.Hobbies.Count == 0 || user == null || otherUser == null || otherUser.Hobbies == null)
            {
                percentages.Add(0);
            }
            else
            {
                percentages.Add(100 * user.Hobbies.Intersect(otherUser.Hobbies).ToList<Hobby>().Count / user.Hobbies.Count);
            }
        }
        return percentages;
    }
}
