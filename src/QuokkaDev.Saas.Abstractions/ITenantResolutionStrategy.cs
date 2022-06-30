namespace QuokkaDev.Saas.Abstractions
{
    /// <summary>
    /// Tenant resolution strategy interface
    /// </summary>
    public interface ITenantResolutionStrategy
    {
        /// <summary>
        /// Resolve tenant identifier from a request
        /// </summary>
        /// <returns>The current tenant identifier</returns>
        string GetTenantIdentifier();
        /// <summary>
        /// Resolve tenant identifier from a request
        /// </summary>
        /// <returns>The current tenant identifier</returns>
        Task<string> GetTenantIdentifierAsync();
    }
}
