namespace QuokkaDev.Saas.Abstractions
{
    /// <summary>
    /// Tenant store
    /// </summary>
    public interface ITenantStore<T, TKey> where T : Tenant<TKey>
    {
        /// <summary>
        /// Get Tenant from the store
        /// </summary>
        /// <param name="identifier">The tenant identifier</param>
        /// <returns>The Tenant</returns>
        Task<T> GetTenantAsync(string identifier);
        /// <summary>
        /// Get Tenant from the store
        /// </summary>
        /// <param name="identifier">The tenant identifier</param>
        /// <returns>The Tenant</returns>
        T GetTenant(string identifier);
    }
}
