using FluentAssertions;
using QuokkaDev.Saas.Abstractions.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace QuokkaDev.Saas.Abstractions.Tests
{
    public class TenantNotFoundExceptionUnitTest
    {
        public TenantNotFoundExceptionUnitTest()
        {
        }

        [Fact(DisplayName = "Exception should be initialized with right values")]
        public void Exception_Should_Be_Initialized_With_Right_Values()
        {
            // Arrange
            TenantNotFoundException ex1 = new() { TenantIdentifier = "my-tenant-identifier" };
            TenantNotFoundException ex2 = new("Error message") { TenantIdentifier = "my-tenant-identifier" };
            TenantNotFoundException ex3 = new("Error message", new System.ArgumentException("Inner error")) { TenantIdentifier = "my-tenant-identifier" };

            // Act            

            // Assert
            ex1.Should().NotBeNull();
            ex1.TenantIdentifier.Should().Be("my-tenant-identifier");
            ex1.Message.Should().Be("Exception of type 'QuokkaDev.Saas.Abstractions.Exceptions.TenantNotFoundException' was thrown.");
            ex1.InnerException.Should().BeNull();

            ex2.Should().NotBeNull();
            ex2.TenantIdentifier.Should().Be("my-tenant-identifier");
            ex2.Message.Should().Be("Error message");
            ex2.InnerException.Should().BeNull();

            ex3.Should().NotBeNull();
            ex3.TenantIdentifier.Should().Be("my-tenant-identifier");
            ex3.Message.Should().Be("Error message");
            ex3.InnerException.Should().NotBeNull();
            ex3.InnerException?.Message.Should().Be("Inner error");
            ex3.InnerException.Should().BeOfType<System.ArgumentException>();
        }

        [Fact(DisplayName = "Serialization works as expected")]
        public void Serialization_Works_As_Expected()
        {
            // Arrange
            TenantNotFoundException ex;

            // Act
            try
            {
                throw new System.ArgumentException("Inner error");
            }
            catch (System.Exception inner)
            {
                try
                {
                    throw new TenantNotFoundException("Error message", inner)
                    {
                        TenantIdentifier = "my-tenant-identifier"
                    };
                }
                catch (TenantNotFoundException e)
                {
                    ex = e;
                }
            }

            using MemoryStream ms = new();

            // BinaryFormatter is used because JsonSerializer and XmlSerializer cannot serialize exception properly

            BinaryFormatter formatter = new();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            formatter.Serialize(ms, ex);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);

#pragma warning disable SYSLIB0011 // Type or member is obsolete
            TenantNotFoundException? deserializedException = (TenantNotFoundException?)formatter.Deserialize(ms);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

            // Assert            
            true.Should().BeTrue();
            deserializedException.Should().NotBeNull();
            deserializedException.Should().NotBeSameAs(ex);
            deserializedException?.TenantIdentifier.Should().Be("my-tenant-identifier");
            deserializedException?.Message.Should().Be("Error message");
            deserializedException?.InnerException.Should().NotBeNull();
            deserializedException?.InnerException.Should().NotBeSameAs(ex.InnerException);
            deserializedException?.InnerException.Should().BeOfType<System.ArgumentException>();
            deserializedException?.InnerException?.Message.Should().Be("Inner error");
        }
    }
}
