using Newtonsoft.Json;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object that represents a filter result.
    /// </summary>
    /// <typeparam name="TResult">The type of the expected query result.</typeparam>
    public class DTOResult<TResult>
    {
        /// <summary>
        ///     Gets the source filter query.
        /// </summary>
        [JsonProperty("filter")]
        public virtual DTOFilter Filter { get; set; }

        /// <summary>
        ///     Gets the result of the query.
        /// </summary>
        [JsonProperty("result")]
        public virtual TResult Result { get; set; }
    }
}