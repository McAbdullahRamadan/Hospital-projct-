﻿namespace Hospital.Utilities
{
    public class PagedResult<T> where T : class
    {
        public PagedResult()
        {

        }
        public List<T> Data { get; set; }
        public int TotalItem { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
