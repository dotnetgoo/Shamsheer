using Shamsheer.Service.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shamsheer.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, PaginationParams @params)
        {
            
            if (@params.PageIndex < 1)
            {
                return source.Take(10);
            }

            if (@params.PageSize < 1)
            {
                return source.Take(@params.PageSize);
            }

            return source.Skip(@params.PageSize * (@params.PageIndex - 1)).Take(@params.PageSize);
        }

        public static IEnumerable<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> source, PaginationParams @params)
        {
            
            if (@params.PageIndex < 1)
            {
                return source.Take(10);
            }

            if (@params.PageSize < 1)
            {
                return source.Take(@params.PageSize);
            }
            

            return source.Skip(@params.PageSize * (@params.PageIndex - 1)).Take(@params.PageSize);
        }

    }
}
