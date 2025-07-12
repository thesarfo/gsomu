namespace Somu.Backend.Dtos;

public class BaseFilter
{
    private int _pageIndex = 0;

    public int PageIndex
    {
        get { return _pageIndex; }
        set
        {
            if (value < 0)
            {
                _pageIndex = 0;
            }
            else
            {
                _pageIndex = value;
            }
        }
    }

    private int _pageSize = 10;

    public int PageSize
    {
        get { return _pageSize; }
        set
        {
            if (value <= 0)
            {
                _pageSize = 10;
            }
            else
            {
                _pageSize = value;
            }
        }
    }

    public string? SortColumn { get; set; }
    public string SortDir { get; set; } = "asc";
}
