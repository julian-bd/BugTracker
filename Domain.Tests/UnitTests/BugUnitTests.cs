using System.Linq;
using AutoFixture;
using Domain.Models;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.UnitTests;

public class BugUnitTests
{
    private readonly Fixture _fixture;

    public BugUnitTests()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    public void TitleAndDescriptionAreSetOnConstruction()
    {
        // Arrange
        var title = _fixture.Create<string>();
        var description = _fixture.Create<string>();

        // Act
        var bug = new Bug(title, description);
        
        // Assert
        bug.Title.Should().Be(title);
        bug.Description.Should().Be(description);
    }
    
    [Fact]
    public void WhenABugIsCreatedItIsOpenByDefault()
    {
        // Arrange
        var bug = new Bug("example-title", "example description");
        
        // Act
        // Assert
        bug.IsOpen.Should().BeTrue();
    }

    [Fact]
    public void WhenABugIsClosedIsOpenReturnsFalse()
    {
        // Arrange
        var bug = new Bug("example-title", "example description");
        
        // Act
        bug.Close();
        
        // Assert
        bug.IsOpen.Should().BeFalse();
    }

    [Fact]
    public void BugsCanBeAssignedToPeople()
    {
        // Arrange
        var bug = new Bug("example-title", "example description");
        var user = new User("user-name");

        // Act
        bug.AssignToUser(user);
        
        // Assert
        var users = bug.Users.ToList();
        users.Count.Should().Be(1);
        users.First().Should().Be(user);
    }
}