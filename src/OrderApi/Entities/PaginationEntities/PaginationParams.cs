namespace OrderApi.Entities.PaginationEntities;

public class PaginationParams
{
    private const int MinPageSize = 1;
    private const int MaxPageSize = 500;

    private int _pageSize = 5;
    private int _pageNumber =1;

    public int PageSize
    {
        get => _pageSize > MaxPageSize ? MaxPageSize : _pageSize <= 0 ? 1 : _pageSize;
        set => _pageSize = value;
    }

    public int CurrentPage
    {
        get => _pageNumber < MinPageSize ? MinPageSize : _pageNumber;
        set => _pageNumber = value;
    }
}