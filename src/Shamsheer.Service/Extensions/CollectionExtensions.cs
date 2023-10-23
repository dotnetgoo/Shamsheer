using Shamsheer.Service.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, PaginationParams @params)
        {
            if (@params.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(@params.PageIndex), "The page index must be greater than or equal to 1.");
            }

            if (@params.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(@params.PageSize), "The page size must be greater than or equal to 1.");
            }

            // Skip the specified number of pages.
            source = source.Skip((@params.PageIndex - 1) * @params.PageSize);

            // Take the specified number of items from the sequence.
            source = source.Take(@params.PageSize);

            return source;
        }

        public static IEnumerable<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> source, PaginationParams @params)
        {
            if (@params.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(@params.PageIndex), "The page index must be greater than or equal to 1.");
            }

            if (@params.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(@params.PageSize), "The page size must be greater than or equal to 1.");
            }

            // Skip the specified number of pages.
            source = source.Skip((@params.PageIndex - 1) * @params.PageSize);

            // Take the specified number of items from the sequence.
            source = source.Take(@params.PageSize);

            return source;
        }

    }
}
