namespace QuokkaDev.Saas.Abstractions
{
    /// <summary>
    /// Tenant information
    /// </summary>
    public class Tenant<TKey>
    {
        private Dictionary<string, object>? _items = null;

        /// <summary>
        /// The tenant Id
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// The tenant name used to filter
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The tenant identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Valid alias for this tenant
        /// </summary>
        public string? Alias { get; set; }

        /// <summary>
        /// Request additional info
        /// </summary>
        public Dictionary<string, object> Items
        {
            get
            {
                _items ??= new Dictionary<string, object>();
                return _items;
            }
        }

        public Tenant(TKey id, string identifier)
        {
            Id = id;
            Identifier = identifier;
        }
    }
}
