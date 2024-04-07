using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silicon_1.Models;

namespace Silicon_1.Controllers;

[Authorize]
public class AccountController(AccountService accountService) : Controller
{
    private readonly AccountService _accountService = accountService;

    public async Task<IActionResult> Details()
    {
        var user = await _accountService.GetuserAsync(User);

        var viewModel = new AccountDetailsViewModel
        {
            AccountBasicInfo = new AccountBasicInfoModel
            {
                Firstname = user.FirstName!,
                Lastname = user.LastName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Biography = user.Bio,
            },
            AdressInfo = new AccountAdressInfo
            {
                AdressLine_1 = user.AddressLine_1!,

            }

        };


        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);
        return RedirectToAction("Details", "Account");
    }
}
