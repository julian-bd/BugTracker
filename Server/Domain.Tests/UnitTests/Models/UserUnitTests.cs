using Domain.Models;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.UnitTests;

public class UserUnitTests
{
    [Fact]
    public void NameIsSetOnInitialisation()
    {
        // Arrange
        var user = new User("kevin");
        
        // Act
        // Assert
        user.Name.Should().Be("kevin");
    }
    
    [Fact]
    public void NameCanBeChanged()
    {
        // Arrange
        var user = new User("kevin");
        
        // Act
        user.ChangeName("alfred");
        
        // Assert
        user.Name.Should().Be("alfred");
    }
}