using Infrastructure.Models;

namespace Silicon_1.Models;

public class CoursesViewModel
{
    public IEnumerable<Category>? Categories { get; set; }

    public IEnumerable<Course>? Courses { get; set; }

    public Pagination? Pagination { get; set; }
}
