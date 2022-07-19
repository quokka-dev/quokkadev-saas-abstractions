# QuokkaDev.Saas.Abstractions
QuokkaDev.Saas.Abstractions contains base types and interfaces for working with QuokkaDev.Saas.

## Tenant\<TKey>
The main class in the package is `Tenant<TKey>`. It's a generic class for describe a Tenant in your [SAAS](https://it.wikipedia.org/wiki/Software_as_a_service) application. You can use it indicating the type of the Id property (TKey) or extend it with your custom implementation. The properties of `Tenant<TKey>` are:

- `Id`. Used for persistence purposes; you must indicate the type of this property when using `Tenant<TKey>`.
- `Name`. A human readable description of the tenant
- `Identifier`. A string for uniquely identify the tenant in you system. Every request to your system should indicate the target Tenant using this string.
- `Alias`. A string for aliasing a tenant. You can identify the same tenant with more identifiers. Please note Alias is not unique, different tenants can have same alias and in this case the first match resolve the tenant. Try avoid using Alias
- `Items`. A dictionary for add extra properties to the tenant during a request. This property is not persisted as default

## ITenantResolutionStrategy
`ITenantResolutionStrategy` is an interface for extracting a Tenant identifier from your application context. Usually, in a web application an implementation of `ITenantResolutionStrategy` should use HTTP context to extract an identifier from the web request. In the NuGet package [QuokkaDev.Saas.ResolutionStrategies](https://github.com/quokka-dev/quokkadev-saas-resolution-strategies) you can find some ready-to-use implementations of this interface, like:

- `HostResolutionStrategy` (resolve tenant identifier from the host part of a web request URL)
- `PathResolutionStrategy` (resolve tenant identifier from the first segment of a web request URL)
- `HeaderResolutionStrategy` (resolve tenant identifier from headers of a web request URL)
- `DevResolutionStrategy` (used for development purpose, use a fixed tenant identifier)

## ITenantStore\<T, TKey>
`ITenantResolutionStrategy` is an interface for loading a Tenant from a persistence store using his identifier. In the package [QuokkaDev.Saas.EntityFramework](https://github.com/quokka-dev/quokkadev-saas-entity-framework) you can find an implementation based on Entity Framework

## ITenantAccessService\<T, TKey>
`ITenantAccessService<T, TKey>` is an interface for resolve a Tenant in the current application context. It should be used only from other QuokkaDev.Saas packages, for access the current Tenant from your application use the `ITenantAccessor<T, TKey>` interface. A ready-to-use implementation of `ITenantAccessService<T, TKey>` can be found in package [QuokkaDev.Saas](https://github.com/quokka-dev/quokkadev-saas)

## ITenantAccessor\<T, TKey>
`ITenantAccessor<T, TKey>` is an interface for accessing a Tenant in the current application context. It should be used from your application. A ready-to-use implementation of `ITenantAccessor<T, TKey>` based on HTTP Context can be found in package [QuokkaDev.Saas](https://github.com/quokka-dev/quokkadev-saas)
