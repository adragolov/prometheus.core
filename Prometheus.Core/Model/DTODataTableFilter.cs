using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object for a data-table filter.
    /// </summary>
    public class DTODataTableFilter
    {
        /// <summary>
        ///     Gets or sets a generic search term of the query.
        /// </summary>
        [JsonProperty("searchTerm")]
        public string SearchTerm { get; set; }

        /// <summary>
        ///     Gets or sets the data table sort order in data table format.
        /// </summary>
        [JsonProperty("order")]
        public string DataTableSortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the max number of results in the data table query.
        /// </summary>
        [JsonProperty("limit")]
        public int? DataTablePageLimit { get; set; }

        /// <summary>
        ///     Gets or sets the current data table page index.
        /// </summary>
        [JsonProperty("page")]
        public int? DataTablePageIndex { get; set; }

        /// <summary>
        ///     Gets or sets the applied sort definitions, based on the <seealso cref="DataTableSortOrder"/> property value.
        /// </summary>
        protected IEnumerable<DTOSortDefinition> SortDefinitions
        {
            get
            {
                if (DataTableSortOrder != null)
                {
                    if (DataTableSortOrder.StartsWith("-"))
                    {
                        return new DTOSortDefinition[]
                        {
                            new DTOSortDefinition()
                            {
                                IsDescending = true,
                                SortKey = DataTableSortOrder.Substring(1)
                            }
                        };
                    }
                    else
                    {
                        return new DTOSortDefinition[]
                        {
                            new DTOSortDefinition()
                            {
                                SortKey = DataTableSortOrder
                            }
                        };
                    }
                }

                return null;
            }
            set
            {
                if (value != null && value.Count() == 1)
                {
                    var singleDefinition = value.ToArray()[0];

                    DataTableSortOrder = $"{(singleDefinition.IsDescending.GetValueOrDefault() ? "-" : string.Empty)}{singleDefinition.SortKey}";
                }
            }
        }

        /// <summary>
        ///     Converts the filter to a generic paging filter.
        /// </summary>
        public virtual DTOPagingFilter ToPagingFilter()
        {
            return new DTOPagingFilter()
            {
                SearchTerm = SearchTerm,
                PageIndex = DataTablePageIndex.HasValue ? (DataTablePageIndex.Value - 1) : DTOPagingFilter.Constants.DefaultPageIndex,
                PageSize = DataTablePageLimit ?? DTOPagingFilter.Constants.DefaultPageSize,
                SortDefinitions = SortDefinitions
            };
        }
    }
}