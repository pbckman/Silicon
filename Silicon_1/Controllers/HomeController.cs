using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Silicon_1.Models;

namespace Silicon_1.Controllers;

public class HomeController(DataContext dataContext) : Controller
{
    private readonly DataContext _dataContext = dataContext;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var subscriberEntity = new SubscriberEntity
            {
                Email = model.Email,
                DailyNewsletter = model.DailyNewsletter,
                AdvertisingUpdates = model.AdvertisingUpdates,
                WeekinReview = model.WeekinReview,
                EventUpdates = model.EventUpdates,
                StartupsWeekly = model.StartupsWeekly,
                Podcasts = model.Podcasts,
            };

            _dataContext.Subscribers.Add(subscriberEntity);
            await _dataContext.SaveChangesAsync();

        }

        return RedirectToAction("Index", "Home");
    }
}
