using FluentAssertions;
using Xunit;

namespace QuokkaDev.Saas.Abstractions.Tests;

public class TenantUnitTest
{
    [Fact(DisplayName = "Tenant should be initialized with right values")]
    public void Tenant_Should_Be_Initialized_With_Right_Values()
    {
        // Arrange
        Tenant<int> tenant = new Tenant<int>(1, "my-tenant-identifier");

        // Act        

        // Assert
        tenant.Should().NotBeNull("an object must be created");
        tenant.Id.Should().Be(1);
        tenant.Identifier.Should().Be("my-tenant-identifier");
        tenant.Items.Should().NotBeNull();
        tenant.Items.Should().BeEmpty();
        tenant.Name.Should().BeNullOrWhiteSpace();
        tenant.Alias.Should().BeNullOrWhiteSpace();
    }
}