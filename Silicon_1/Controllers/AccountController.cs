﻿using Infrastructure.Models;
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
        var user = await _accountService.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel
        {
            AccountBasicInfo = new AccountBasicInfoModel
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Biography = user.Bio,
            },
            AddressInfo = new AccountAddressInfo
            {
                AddressLine_1 = user.AddressLine_1!,
                AddressLine_2 = user.AddressLine_2,
                PostalCode = user.PostalCode!,
                City = user.City!,
            }
        };

        return View(viewModel);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
    {
        if (model.AccountBasicInfo != null)
        {
            if (!string.IsNullOrEmpty(model.AccountBasicInfo.FirstName) && !string.IsNullOrEmpty(model.AccountBasicInfo.LastName))
            {
                var result = await _accountService.UpdatebasicInfoAsync(User, model.AccountBasicInfo);
            }
        }
        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAddressInfo(AccountDetailsViewModel model)
    {
        if (model.AddressInfo != null)
        {
            if (!string.IsNullOrEmpty(model.AddressInfo.AddressLine_1) && !string.IsNullOrEmpty(model.AddressInfo.PostalCode) && !string.IsNullOrEmpty(model.AddressInfo.City))
            {
                var result = await _accountService.UpdateAddressInfoAsync(User, model.AddressInfo);
            }
        }
        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);
        return RedirectToAction("Details", "Account");
    }
}
