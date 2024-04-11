using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_1.Models;


namespace Silicon_1.Controllers;

public class ContactController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;
    private string _serviceApiUrl = "https://localhost:7155/api/Service";
    private string _contactRequestApiUrl = "https://localhost:7155/api/ContactRequest";

    [HttpGet]
    public async Task<IActionResult> Index(string service = "")
    {

        var viewModel = new ContactRequestViewModel();

        var response = await _http.GetAsync(_serviceApiUrl);
        if (response.IsSuccessStatusCode)
        {
            var services = JsonConvert.DeserializeObject<IEnumerable<Service>>(await response.Content.ReadAsStringAsync());
            if (services != null)
                viewModel.Service = services;
        }

        //var requestResponse = await _http.GetAsync($"{_contactRequestApiUrl}?category={Uri.EscapeDataString(service)}");
        //if (requestResponse.IsSuccessStatusCode)
        //{

        //}

        return View(viewModel);
    }


    [HttpPost]
    public async Task<IActionResult> ContactRequest(ContactRequestViewModel model)
    {
        if (ModelState.IsValid)
        {
            var contactRequest = new ContactRequest
            {
                Id = Guid.NewGuid().ToString(),
                FullName = model.FullName!,
                Email = model.Email!,
                ContactMessage = model.ContactMessage,
                ServiceId = model.ServiceId
            };

            var json = JsonConvert.SerializeObject(contactRequest);
            Console.WriteLine(json);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(_contactRequestApiUrl, content);
            

            if (!response.IsSuccessStatusCode)
            {
                return View(model);
            }

            
        }

        return RedirectToAction("Index", "Contact");
    }






}
