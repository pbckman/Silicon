namespace Infrastructure.Models;

public class Pagination
{
    public int Currentpage { get; set; }
    public int TotalPages { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public void UpdateTotalPages()
    {
        TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
