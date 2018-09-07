using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Prometheus.Core.Validation
{
    /// <summary>
    ///     Validation attribute that is applied against collections and validates the
    ///     configured minimum of elements in the collection.
    /// </summary>
    public class MinArrayCountAttribute : ValidationAttribute
    {
        /// <summary>
        ///     Specifies the minimum number of objects in the target validation object.
        /// </summary>
        protected readonly int _MinCount;

        /// <summary>
        ///     Creates a new instance of the attribute class.
        /// </summary>
        /// <param name="minCount">Specifies the minimum number of objects in the collection.</param>
        public MinArrayCountAttribute(int minCount)
        {
            _MinCount = minCount;
        }

        /// <summary>
        ///     Returns the number of items in an enumerable source.
        /// </summary>
        /// <param name="source">The enumerable, required.</param>
        protected int CountEnumerable(IEnumerable source)
        {
            var counter = 0;
            var e = source.GetEnumerator();
            {
                while (e.MoveNext()) counter++;
            }
            return counter;
        }

        /// <summary>
        ///     Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>True if the validation passes, false otherwise.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var enumerable = value as IEnumerable;
            
            if (enumerable == null)
            {
                return new ValidationResult($"The target validation property '{validationContext.DisplayName}' is not an IEnumerable source.");
            }

            var objectCount = CountEnumerable(enumerable);

            if (objectCount < _MinCount)
            {
                return new ValidationResult(
                    $"The target validation collection property '{validationContext.DisplayName}' has {objectCount} elements, but the validation requires at least {_MinCount} elements."
                );
            }

            return ValidationResult.Success;
        }
    }
}
