using System.Runtime.Serialization;

namespace QuokkaDev.Saas.Abstractions.Exceptions
{
    [Serializable]
    public class TenantNotFoundException : Exception
    {
        public string? TenantIdentifier { get; set; }

        public TenantNotFoundException() : base()
        {
        }

        public TenantNotFoundException(string? message) : base(message)
        {
        }

        public TenantNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TenantNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.TenantIdentifier = info.GetString(nameof(TenantIdentifier));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(TenantIdentifier), TenantIdentifier);
        }
    }
}
