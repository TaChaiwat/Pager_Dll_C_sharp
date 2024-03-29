﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pager
{
    public class ViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public Pager Pager { get; set; }
        public ParameterPager ParameterPager { get; set; }
    }

    public class Pager
    { 
        public Pager(int totalItems, int? page, int pageSize = 20)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }  
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }

   

    public class ParameterPager{

        public ParameterPager()
        {
            page = 1;
            PageSetNumber = 25;
        }
        public string sorting { get; set; }
        public string currentSort { get; set; }
        public bool UsageStatus { get; set; } 

        public int page { get; set; }
        public int PageSetNumber { get; set; }
    }
}
