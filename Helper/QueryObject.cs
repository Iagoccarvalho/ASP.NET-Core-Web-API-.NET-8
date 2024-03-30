namespace Api_NET8.Helper
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = null; //Sorting
        public bool IsDecsending { get; set; } = false;
    }
}
