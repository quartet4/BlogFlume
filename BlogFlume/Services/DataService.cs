using BlogFlume.Data;
using BlogFlume.Enums;
using BlogFlume.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogFlume.Services;

public class DataService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<BlogUser> _userManager;

    public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
    {
        _dbContext = dbContext;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task ManageDataAsync()
    {
        // Create DB from migrations
        await _dbContext.Database.MigrateAsync();

        // Seed a few roles into system
        await SeedRolesAsync();

        // Seed a few users into system
        await SeedUsersAsync();
    }

    private async Task SeedRolesAsync()
    {
        // If roles in system already, do nothing
        if (_dbContext.Roles.Any())
        {
            return;
        }

        // Otherwise create a few roles
        foreach (var role in Enum.GetNames(typeof(BlogRole)))
        {
            // Use role manager to create roles
            await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    private async Task SeedUsersAsync()
    {
        // If users in system already, do nothing
        if (_dbContext.Users.Any())
        {
            return;
        }

        // Otherwise create a few users
        var adminUser = new BlogUser()
        {
            Email = "quartet4@mac.com",
            UserName = "quartet4",
            FirstName = "Jonathan",
            LastName = "Mendoza",
            PhoneNumber = "(626) 400-0180",
            EmailConfirmed = true
        };

        await _userManager.CreateAsync(adminUser, "ChanWoo1!");
        await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

        var modUser = new BlogUser()
        {
            Email = "quartet4@gmail.com",
            UserName = "q4core",
            FirstName = "Jon",
            LastName = "Mendoza",
            PhoneNumber = "(626) 400-0180",
            EmailConfirmed = true
        };

        await _userManager.CreateAsync(modUser, "ChanWoo1!");
        await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
    }
}