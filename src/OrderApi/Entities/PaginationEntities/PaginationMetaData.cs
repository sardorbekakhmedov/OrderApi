namespace OrderApi.Entities.HelperEntities;

public class PaginationMetaData
{
    public int TotalListCount { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int CurrentPage { get; }
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    public PaginationMetaData(int totalListCount, int pageSize, int currentPageNumber)
    {
        TotalListCount = totalListCount;
        PageSize = pageSize;
        CurrentPage = currentPageNumber;
        TotalPages = (int)Math.Ceiling(totalListCount / (double)PageSize);
    }
}