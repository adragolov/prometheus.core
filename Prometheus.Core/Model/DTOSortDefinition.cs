using Newtonsoft.Json;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object that defines a sort to be applied as part of a query.
    /// </summary>
    public class DTOSortDefinition
    {
        /// <summary>
        ///     Gets the name of the property to sort on.
        /// </summary>
        [JsonProperty("sortKey")]
        public string SortKey { get; set; }

        /// <summary>
        ///     Gets an indication, if this descending filter is needed.
        /// </summary>
        [JsonProperty("isDescending")]
        public bool? IsDescending { get; set; }
    }
}