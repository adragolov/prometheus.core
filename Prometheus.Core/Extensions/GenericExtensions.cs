using System;

namespace Prometheus.Core.Extensions
{
    /// <summary>
    ///     Generic method extensions.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        ///     Performs an objec transform via piping function.
        /// </summary>
        /// <typeparam name="T">The type of the source object.</typeparam>
        /// <param name="source">The source object. Required.</param>
        /// <param name="pipeFunc">The piping / transforming function.</param>
        public static T Pipe<T>(this T source, Func<T, T> pipeFunc)
        {
            return pipeFunc(source);
        }
    }
}
