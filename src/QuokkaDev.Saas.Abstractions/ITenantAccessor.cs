namespace QuokkaDev.Saas.Abstractions
{
    /// <summary>
    /// Provide access to the current Tenant
    /// </summary>
    /// <typeparam name="T">Type of the tenant</typeparam>
    /// <typeparam name="TKey">Type of the tenant key</typeparam>
    public interface ITenantAccessor<T, TKey> where T : Tenant<TKey>
    {
        /// <summary>
        /// The current tenant
        /// </summary>
        T? Tenant { get; }
    }
}
