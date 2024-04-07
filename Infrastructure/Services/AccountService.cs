using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Infrastructure.Services;

public class AccountService(UserManager<UserEntity> userManager, DataContext dataContext, IConfiguration configuration)
{
    private readonly UserManager<UserEntity> userManager = userManager;
    private readonly DataContext dataContext = dataContext;
    private readonly IConfiguration configuration = configuration;


    public async Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal)
    {
        var nameIdentifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var userEntity = await dataContext.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);

        if (userEntity != null) 
        {
            return UserFactory.Create(userEntity!);
        }
        return null!;
    }

    public async Task<bool> UploadUserProfileImageAsync(ClaimsPrincipal userClaims, IFormFile file)
    {
        try
        {
            if (userClaims != null && file != null && file.Length != 0) 
            {
                var user = await userManager.GetUserAsync(userClaims);
                if (user != null)
                {
                    var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @configuration["FilePath:ProfileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    user.ProfileImage = fileName;
                    dataContext.Update(user);
                    await dataContext.SaveChangesAsync();

                    return true;
                }
            }
        }
        catch { }
        return false;
    }

    public async Task<UserEntity> GetuserAsync(ClaimsPrincipal claimsPrincipal)
    {
        var user = await userManager.GetUserAsync(claimsPrincipal);
        return user;
    }
}
