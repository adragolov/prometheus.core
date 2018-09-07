namespace Prometheus.Core.Extensions
{
    using Prometheus.Core.Model;
    using System;

    /// <summary>
    ///     Extensions methods for the System.Exception class.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        ///     Maps the exception object to a business error object.
        /// </summary>
        /// <param name="source">
        ///     The source exception object.
        /// </param>
        /// <param name="errorCode">
        ///     The domain specific error code for the business error.
        /// </param>
        /// <param name="isFatalError">
        ///     Indicator, if the exception is a fatal one and recovery is not possible.
        /// </param>
        public static BusinessError ToBusinessError(this Exception source, int? errorCode = default(int?), bool? isFatalError = default(bool?))
        {
            return BusinessError.FromException(source, errorCode, isFatalError);
        }
    }
}