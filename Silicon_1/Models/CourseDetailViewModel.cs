namespace Silicon_1.Models;

public class CourseDetailViewModel
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string OriginalPrice { get; set; }
    public string DiscountPrice { get; set; }
    public int Hours { get; set; }
    public string LikesInProcent { get; set; }
    public string NumberOfLikes { get; set; }
    public bool IsDigital { get; set; }
    public bool IsBestseller { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ImageUrl { get; set; }
    public string BigImageUrl { get; set; }
    public int CourseDetailsId { get; set; }
    public CourseDetailsViewModel CourseDetails { get; set; }
}

public class CourseDetailsViewModel
{
    public int Id { get; set; }
    public string TitleDescription { get; set; }
    public string AuthorImgUrl { get; set; }
    public string CourseDescription { get; set; }
    public List<string> WhatYouWillLearn { get; set; }
    public List<ProgramDetailViewModel> ProgramDetails { get; set; }
}

public class ProgramDetailViewModel
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}

