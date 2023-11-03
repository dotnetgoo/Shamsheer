using System;
using System.Text.RegularExpressions;

namespace Shamsheer.Service.Configurations;

public class PaginationMetaData
{
    public int CurrentPage { get; set; }       // 5
    public int TotalPages { get; set; }         //20
    public int TotalCount { get; set; }         //40
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginationMetaData(int totalCount, PaginationParams @params)
    {
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount/(double)@params.PageSize);
        CurrentPage = @params.PageIndex;
    }

}
