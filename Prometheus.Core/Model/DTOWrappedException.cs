using Newtonsoft.Json;
using System;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Data transfer object for a <seealso cref="System.Exception"/>.
    /// </summary>
    public class DTOWrappedException
    {
        /// <summary>
        ///     Gets the message for the exception.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        ///     Gets the inner exception object.
        /// </summary>
        [JsonProperty("innerException")]
        public DTOWrappedException InnerException { get; set; }

        /// <summary>
        ///     Gets the exception stack trace.
        /// </summary>
        [JsonProperty("stackTrace")]
        public string StackTrace { get; set; }

        /// <summary>
        ///     Gets the source context for the exception.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        ///     Gets an optional HResult, low level index of the exception.
        /// </summary>
        [JsonProperty("hResult")]
        public int? HResult { get; set; }

        /// <summary>
        ///     Gets the generated help link for the exception.
        /// </summary>
        [JsonProperty("helpLink")]
        public string HelpLink { get; set; }

        /// <summary>
        ///     Initializer of the class.
        /// </summary>
        public DTOWrappedException()
        {

        }

        /// <summary>
        ///     Initializer of the class.
        /// </summary>
        /// <param name="e">The source exception object.</param>
        public DTOWrappedException(Exception e)
        {
            Message = e?.Message;
            StackTrace = e?.StackTrace;
            Source = e?.Source;
            InnerException = (e != null && e.InnerException != null) ?
                new DTOWrappedException(e.InnerException) :
                null;
            HelpLink = e?.HelpLink;
            HResult = e?.HResult;
        }
    }
}