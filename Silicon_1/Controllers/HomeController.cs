using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Silicon_1.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Silicon_1.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _dataContext;
    private readonly HttpClient _httpClient;

    public HomeController(DataContext dataContext, IHttpClientFactory httpClientFactory)
    {
        _dataContext = dataContext;
        _httpClient = httpClientFactory.CreateClient();
    }

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

            var json = JsonSerializer.Serialize(subscriberEntity);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7155/api/Subscriber", content);
            
            if(!response.IsSuccessStatusCode)
            {
                return View(model);
            }
        }

        return RedirectToAction("Index", "Home");
    }
}
