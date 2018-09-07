using System.ComponentModel.DataAnnotations;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object for a property value.
    /// </summary>
    public class DTOPropertyValue
    {
        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        [Required]
        public string Key { get; set; }

        /// <summary>
        ///     Gets the value type of the property.
        /// </summary>
        [Required]
        public string ValueType { get; set; }

        /// <summary>
        ///     Gets the value of the property.
        /// </summary>
        [Required]
        public string Value { get; set; }
    }
}