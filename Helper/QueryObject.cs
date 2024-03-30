﻿namespace Api_NET8.Helper
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        //Sorting
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        //Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
