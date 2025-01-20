namespace InterviewRating.Application.Common;

public class PageQueryResponse
{
    public string? SearchTerm { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
