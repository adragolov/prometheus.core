using Newtonsoft.Json;
using System.Collections.Generic;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object for a paging result item.
    /// </summary>
    /// <typeparam name="TResultItem">The type of the items in the paging result.</typeparam>
    public class DTOResultPaging<TResultItem> : DTOResult<IEnumerable<TResultItem>>
    {
        /// <summary>
        ///     Gets the paging filter object, if any is applied.
        /// </summary>
        [JsonIgnore]
        public virtual DTOPagingFilter PagingFilter
        {
            get
            {
                if (Filter != null)
                {
                    return Filter as DTOPagingFilter;
                }

                return null;
            }

            set
            {
                Filter = value;
            }
        }

        /// <summary>
        ///     Gets the total number of items in the paging result.
        /// </summary>
        [JsonProperty("totalCount")]
        public long TotalResultsCount { get; set; }

        /// <summary>
        ///     Gets the computed value for the total number of result pages.
        ///     Requires correct values for TotalResultsCount and PagingFilter.PageSize.
        /// </summary>
        [JsonProperty("totalPages")]
        public int? TotalNumberOfPages
        {
            get
            {
                if (PagingFilter != null && PagingFilter.PageSize > 0)
                {
                    return (int)System.Math.Ceiling((double)TotalResultsCount / PagingFilter.PageSize);
                }

                return null;
            }
        }

        /// <summary>
        ///     Creates a paging result for the specified paging filter.
        /// </summary>
        /// <param name="filter">The input query filter. Required.</param>
        /// <param name="results">The results for the specified filter page from the query operation. Required.</param>
        /// <param name="totalResultsCount">The total number of results from the query operation. Required.</param>
        public static DTOResultPaging<TResultItem> CreateResult(
            DTOPagingFilter filter, 
            IEnumerable<TResultItem> results,
            long totalResultsCount)
        {
            return new DTOResultPaging<TResultItem>()
            {
                Result = results,
                Filter = filter,
                TotalResultsCount = totalResultsCount
            };
        }
    }
}