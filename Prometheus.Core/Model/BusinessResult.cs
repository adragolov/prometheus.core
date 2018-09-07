using System;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Represents the result of a business processing operation.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the result expected value.
    /// </typeparam>
    public class BusinessResult<T>
    {
        /// <summary>
        ///     Gets the underlying processing error object.
        ///     Available for unsuccessful results.
        /// </summary>
        public BusinessError Error { get; protected set; }

        /// <summary>
        ///     For error results, stores a reference to the underlying exception
        ///     object that has caused the error. Not serialized in JSON responses.
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public Exception SourceException
        {
            get { return Error?.SourceException; }
        }
        
        /// <summary>
        ///     Gets the the business processing output value.
        ///     Available for successful results only.
        /// </summary>
        public T Output { get; protected set; }

        /// <summary>
        ///     Gets an indication, if the business result is a faulty one.
        /// </summary>
        public bool IsError { get { return Error != null; } }
        
        /// <summary>
        ///     Gets an optional context value for the business processing.
        /// </summary>
        public object Context { get; protected set; }

        /// <summary>
        ///     Creates a successful business result.
        /// </summary>
        /// <param name="output">The success result object.</param>
        /// <param name="context">Optional context object for the business process.</param>
        public static BusinessResult<T> Success(T output, object context = null)
        {
            return new BusinessResult<T>
            { 
                Output = output,
                Context = context,
            };
        }

        /// <summary>
        ///     Creates an error business result.
        /// </summary>
        /// <param name="error">The error object, required.</param>
        /// <param name="context">Optional context object for the business process.</param>
        public static BusinessResult<T> Fail(BusinessError error, object context = null)
        {
            if (error == null) throw new ArgumentNullException(nameof(error));

            return new BusinessResult<T>
            {
                Error = error,
                Context = context,
            };
        }
        
        /// <summary>
        ///     Creates an error business result.
        /// </summary>
        /// <param name="exception">The error source exception object, required.</param>
        /// <param name="errorCode">Domain specific error code, optional.</param>
        /// <param name="context">Optional context object for the business process.</param>
        public static BusinessResult<T> Fail(Exception exception, int? errorCode = default(int?), object context = null)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            return new BusinessResult<T>
            {
                Error = BusinessError.FromException(exception, errorCode),
                Context = context,
            };
        }

        /// <summary>
        ///     Creates an error business result.
        /// </summary>
        /// <param name="message">The error message, required.</param>
        /// <param name="errorCode">Domain specific error code, optional.</param>
        /// <param name="context">Optional context object for the business process.</param>
        public static BusinessResult<T> Fail(string message, int? errorCode = default(int?), object context = null)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            return new BusinessResult<T>
            {
                Error = BusinessError.FromException(new ApplicationException(message), errorCode),
                Context = context,
            };
        }
    }

    /// <summary>
    ///     Represents the result of a business processing operation.
    /// </summary>
    public class BusinessResult : BusinessResult<object>
    {
        /// <summary>
        ///     Creates a successful business result.
        /// </summary>
        /// <param name="output">The success result object.</param>
        /// <param name="context">Optional context object for the business process.</param>
        /// <typeparam name="T">
        ///     The type of the result expected value.
        /// </typeparam>
        public static BusinessResult<T> Success<T>(T output, object context = null)
        {
            return BusinessResult<T>.Success(output, context);
        }

        /// <summary>
        ///     Creates an error business result.
        /// </summary>
        /// <param name="error">The error object, required.</param>
        /// <param name="context">Optional context object for the business process.</param>
        /// <typeparam name="T">
        ///     The type of the result expected value.
        /// </typeparam>
        public static BusinessResult<T> Fail<T>(BusinessError error, object context = null)
        {
            return BusinessResult<T>.Fail(error, context);
        }

        /// <summary>
        ///     Creates an error business result.
        /// </summary>
        /// <param name="exception">The error source exception object, required.</param>
        /// <param name="errorCode">Domain specific error code, optional.</param>
        /// <param name="context">Optional context object for the business process.</param>
        /// <typeparam name="T">
        ///     The type of the result expected value.
        /// </typeparam>
        public static BusinessResult<T> Fail<T>(Exception exception, int? errorCode = default(int?), object context = null)
        {
            return BusinessResult<T>.Fail(exception, errorCode, context);
        }
    }
}