using System.ComponentModel;

namespace BaseEntityLib
{
    /// <summary>
    /// Response
    /// </summary>
    public class Response<T> where T : class
    {
        public Response()
        {
        }

        public Response(ResponseStatus status, T? data, string? message = null)
        {
            if (!Enum.IsDefined(typeof(ResponseStatus), status))
                throw new InvalidEnumArgumentException(nameof(status), (int)status, typeof(ResponseStatus));

            Status = status;
            Data = data ?? throw new ArgumentNullException(nameof(data));
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        /// Status
        /// </summary>
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; } = null!;

        /// <summary>
        /// Message
        /// </summary>
        public string? Message { get; set; }
    }
}