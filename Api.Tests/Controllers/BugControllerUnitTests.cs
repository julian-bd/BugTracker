using System;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Requests;
using AutoFixture;
using Domain.DataStorage;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Api.Tests.Controllers;

public class BugControllerUnitTests
{
    private readonly Fixture _fixture;

    public BugControllerUnitTests()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    public async Task GetAllReturnsAllBugsFromRepository()
    {
        // Arrange
        var expectedBugs = _fixture.CreateMany<Bug>().ToList();
        var fakeBugRepository = A.Fake<IRepository<Bug>>();
        A.CallTo(() => fakeBugRepository.GetAll())
            .Returns(expectedBugs);
        
        var controller = new BugController(fakeBugRepository);
        
        // Act
        var result = await controller.GetAll();
        
        // Assert
        result.Should().BeEquivalentTo(expectedBugs);
    }

    [Fact]
    public async Task GetByIdReturnsDesiredBugFromRepository()
    {
        // Arrange
        var bugId = Guid.NewGuid();
        var expectedBug = _fixture.Build<Bug>()
            .With(x => x.Id, bugId)
            .Create();
        
        var fakeBugRepository = A.Fake<IRepository<Bug>>();
        A.CallTo(() => fakeBugRepository.GetById(bugId))
            .Returns(expectedBug);
        
        var controller = new BugController(fakeBugRepository);
        
        // Act
        var result = await controller.GetById(bugId);
        
        // Assert
        result.Should().BeEquivalentTo(expectedBug);
    }

    [Fact]
    public async Task CreateSavesBugToRepository()
    {
        // Arrange
        var request = _fixture.Create<CreateBug>();
        var fakeBugRepository = A.Fake<IRepository<Bug>>();
        var controller = new BugController(fakeBugRepository);
        
        // Act
        await controller.Create(request);
        
        // Assert
        A.CallTo(() => fakeBugRepository.Create(A<Bug>.That.Matches(x =>
                x.Title == request.Title && x.Description == request.Description)))
            .MustHaveHappenedOnceExactly();
    }
    
    [Fact]
    public async Task UpdateSavesBugToRepository()
    {
        // Arrange
        var request = _fixture.Create<UpdateBug>();
        var fakeBugRepository = A.Fake<IRepository<Bug>>();
        var controller = new BugController(fakeBugRepository);
        
        // Act
        await controller.Update(request);
        
        // Assert
        A.CallTo(() => fakeBugRepository.Update(request.Bug))
            .MustHaveHappenedOnceExactly();
    }
}