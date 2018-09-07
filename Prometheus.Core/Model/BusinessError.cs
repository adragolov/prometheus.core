using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object that carries information about a business level error and its context.
    /// </summary>
    public class BusinessError
    {
        /// <summary>
        ///     Stores the underlying error message.
        /// </summary>
        [Required]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Stores the error code, an integer number, that is specific to the business domain.
        ///     When provided, allows the consumers of the error object to act accordingly, e.g.
        ///     display a user-friendly message.
        /// </summary>
        public int? ErrorCode { get; set; }

        /// <summary>
        ///     Optionally stores an indication if the error is a fatal one within the business domain.
        ///     When provided, allows the consumers of the error object to allow a more user-friendly,
        ///     graceful exit from your application.
        /// </summary>
        public bool? IsFatalError { get; set; }

        /// <summary>
        ///     Optionally stores additional text information related to the error business context.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        ///     Optionally stores the context exception for this error (if available).
        ///     Not serialized in JSON responses.
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public Exception SourceException { get; protected set; }

        /// <summary>
        ///     A key-value store that persists additional meta data associated with error, for example
        ///     process or thread id, environment name, etc.
        /// </summary>
        public Dictionary<string, object> ErrorInfo { get; protected set; }
            = new Dictionary<string, object>();
        
#if DEBUG
        /// <summary>
        ///     Returns a string representation of th object.
        /// </summary>
        public override string ToString()
        {
            if (ErrorCode.HasValue)
            {

                return $"[Error {ErrorCode}] {ErrorMessage}.";
            }

            return $"[Error] {ErrorMessage}.";
        }
#endif

        /// <summary>
        ///     Creates an instance of the class from a source exception object.
        /// </summary>
        /// <param name="e">The exception object, required.</param>
        /// <param name="errorCode">Optionally, the domain specific error code.</param>
        /// <param name="isFatalError">Optionally specifies if the exception is a fatal one.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown, if the source exception argument 'e' is NULL.
        /// </exception>
        public static BusinessError FromException(Exception e, int? errorCode = default(int?), bool? isFatalError = default(bool?))
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            var result = new BusinessError
            {
                ErrorCode = errorCode,
                ErrorMessage = e.Message,
                IsFatalError = isFatalError,
                SourceException = e
            };

            result.ErrorInfo.TryAdd(nameof(e.StackTrace), e.StackTrace);

            return result;
        }

        /// <summary>
        ///     Creates an instance of the class from an error message text.
        /// </summary>
        /// <param name="errorMessage">The error message, required.</param>
        /// <param name="errorCode">The domain specific error code, optional.</param>
        /// <param name="isFatalError">Specifies if the exception is a fatal one.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown, if the source exception argument 'errorMessage' is NULL.
        /// </exception>
        public static BusinessError FromMessage(string errorMessage, int? errorCode = default(int?), bool? isFatalError = default(bool?))
        {
            if (errorMessage == null) throw new ArgumentNullException(nameof(errorMessage));

            var result = new BusinessError
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage,
                IsFatalError = isFatalError
            };

            return result;
        }
    }
}