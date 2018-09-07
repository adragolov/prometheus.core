using Newtonsoft.Json;
using System.Collections.Generic;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object for a basic filter.
    /// </summary>
    public class DTOFilter
    {
        /// <summary>
        ///     Gets a generic search term.
        /// </summary>
        [JsonProperty("searchTerm")]
        public virtual string SearchTerm { get; set; }

        /// <summary>
        ///     Gets the collection of prioritized sort definitions.
        /// </summary>
        [JsonProperty("sortDefinitions")]
        public virtual IEnumerable<DTOSortDefinition> SortDefinitions { get; set; }
    }
}