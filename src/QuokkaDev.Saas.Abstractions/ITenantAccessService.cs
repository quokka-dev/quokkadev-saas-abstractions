namespace QuokkaDev.Saas.Abstractions
{
    /// <summary>
    /// Service for access to the current tenant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface ITenantAccessService<T, TKey> where T : Tenant<TKey>
    {
        /// <summary>
        /// Get the current tenant
        /// </summary>
        /// <returns>The current tenant</returns>
        Task<T> GetTenantAsync();
        /// <summary>
        /// Get the current tenant
        /// </summary>
        /// <returns>The current tenant</returns>
        T GetTenant();
    }
}
