using System;

namespace Prometheus.Core.Model
{
    /// <summary>
    ///     Exception thrown when a required business object already exists.
    /// </summary>
    public class ObjectAlreadyExistsException : Exception
    {
        /// <summary>
        ///     Gets the type of the target business object.
        /// </summary>
        public Type ObjectType { get; protected set; }

        /// <summary>
        ///     Gets the unique key of the business object.
        /// </summary>
        public string ObjectKey { get; protected set; }

        /// <summary>
        ///     Creates a new exception instance.
        /// </summary>
        /// <param name="objectType">The type of the target busines object.</param>
        /// <param name="objectKey">The unique key of the object.</param>
        public ObjectAlreadyExistsException(Type objectType, string objectKey) : base("Object already exists.")
        {
            ObjectType = objectType ?? typeof(object);
            ObjectKey = objectKey;
        }
        /// <summary>
        ///     Creates a new exception instance.
        /// </summary>
        /// <param name="objectType">The type of the target busines object.</param>
        /// <param name="objectKey">The unique key of the object.</param>
        /// <param name="message">The exception message.</param>
        public ObjectAlreadyExistsException(string message, Type objectType, string objectKey) : base(message)
        {
            ObjectType = objectType ?? typeof(object);
            ObjectKey = objectKey;
        }
        /// <summary>
        ///     Creates a new exception instance.
        /// </summary>
        /// <param name="objectType">The type of the target busines object.</param>
        /// <param name="objectKey">The unique key of the object.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception of the failure stack.</param>
        public ObjectAlreadyExistsException(string message, Exception innerException, Type objectType, string objectKey) : base(message, innerException)
        {
            ObjectType = objectType ?? typeof(object);
            ObjectKey = objectKey;
        }
    }
}