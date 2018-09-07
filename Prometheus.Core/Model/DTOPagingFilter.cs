using Newtonsoft.Json;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Represents an extended filter that provides for result paging.
    /// </summary>
    public class DTOPagingFilter : DTOFilter
    {
        /// <summary>
        ///     Defaults used by the filter.
        /// </summary>
        public static class Constants
        {
            /// <summary>
            ///     The default page size.
            /// </summary>
            public const int DefaultPageSize = 50;
            /// <summary>
            ///     The default page index.
            /// </summary>
            public const int DefaultPageIndex = 0;
            /// <summary>
            ///     The max number of page results.
            /// </summary>
            public const int MaxPageSize = 1000;
            /// <summary>
            ///     The min number of page results.
            /// </summary>
            public const int MinPageSize = 5;
        }

        /// <summary>
        ///     Singleton default value of the filter.
        /// </summary>
        public static readonly DTOPagingFilter Default = CreateDefault();

        /// <summary>
        ///     Gets or sets the page size of the filter.
        /// </summary>
        [JsonProperty("pageSize")]
        public virtual int PageSize { get; set; }
            = Constants.DefaultPageSize;

        /// <summary>
        ///     Gets or sets the page index of the filter.
        /// </summary>
        [JsonProperty("pageIndex")]
        public virtual int PageIndex { get; set; }
            = Constants.DefaultPageIndex;

        /// <summary>
        ///     Creates a default paging filter.
        /// </summary>
        public static DTOPagingFilter CreateDefault()
        {
            return new DTOPagingFilter()
            {
                PageSize = Constants.DefaultPageIndex,
                PageIndex = Constants.DefaultPageIndex
            };
        }
    }
}