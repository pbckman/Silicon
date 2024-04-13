using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_1.Models;

namespace Silicon_1.Controllers;

public class CoursesController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;
    private string _categoryApiUrl = "https://localhost:7155/api/Categories";
    private string _courseApiUrl = "https://localhost:7155/api/Course";

    public async Task<IActionResult> Index(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        var viewModel = new CoursesViewModel();

        var categoryResponse = await _http.GetAsync(_categoryApiUrl);
        if (categoryResponse.IsSuccessStatusCode)
        {
            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(await categoryResponse.Content.ReadAsStringAsync());
            if (categories != null)
                viewModel.Categories = categories;
        }

        var courseResponse = await _http.GetAsync($"{_courseApiUrl}?category={Uri.EscapeDataString(category)}&searchQuery={Uri.EscapeDataString(searchQuery)}&pageNumber={pageNumber}&pageSize={pageSize}");
        if (courseResponse.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<CourseResult>(await courseResponse.Content.ReadAsStringAsync());
            if (result != null)
            {
                viewModel.Courses = result.Courses;
                viewModel.Pagination = new Pagination
                {
                    PageSize = pageSize,
                    Currentpage = pageNumber,
                    TotalPages = result.TotalPages,
                    TotalCount = result.TotalItems,
                };
            }
        }

        return View(viewModel);
    }


    public async Task<IActionResult> CourseDetails(string id)
    {
        var response = await _http.GetAsync($"https://localhost:7155/api/Course/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var course = JsonConvert.DeserializeObject<CourseDetailViewModel>(await response.Content.ReadAsStringAsync());
            return View(course);
        }
        return NotFound();
    }
}
