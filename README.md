# QuokkaDev.Saas.Abstractions
QuokkaDev.Saas.Abstractions contains base types and interfaces for working with QuokkaDev.Saas.

## Tenant\<TKey>
The main class in the package is `Tenant<TKey>`. It's a generic class for describe a Tenant in your [SAAS](https://it.wikipedia.org/wiki/Software_as_a_service) application. You can use it indicating the type of the Id property (TKey) or extend it with your custom implementation. The properties of `Tenant<TKey>` are:

- `Id`. Used for persistence purposes; you must indicate the type of this property when using `Tenant<TKey>`.
- `Name`. A human readable description of the tenant
- `Identifier`. A string for uniquely identify the tenant in you system. Every request to your system should indicate the target Tenant using this string.
- `Alias`. A string for aliasing a tenant. You can identify the same tenant with more identifiers. Please note Alias is not unique, different tenants can have same alias and in this case the first match resolve the tenant. Try avoid using Alias
- `Items`. A dictionary for add extra properties to the tenant during a request. This property is not persisted as default