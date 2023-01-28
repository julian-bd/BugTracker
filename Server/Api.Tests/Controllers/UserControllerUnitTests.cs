using System;
using System.Threading.Tasks;
using API.Controllers;
using API.Requests;
using API.Requests.User;
using AutoFixture;
using Domain.DataStorage;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Api.Tests.Controllers;

public class UserControllerUnitTests
{
    private readonly Fixture _fixture;

    public UserControllerUnitTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public async Task GetByIdReturnsDesiredUserFromRepository()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var expectedUser = _fixture.Build<User>()
            .With(x => x.Id, userId)
            .Create();

        var fakeUserRepository = A.Fake<IRepository<User>>();
        A.CallTo(() => fakeUserRepository.GetById(userId))
            .Returns(expectedUser);

        var controller = new UserController(fakeUserRepository);

        // Act
        var result = await controller.GetById(userId);

        // Assert
        result.Should().BeEquivalentTo(expectedUser);
    }

    [Fact]
    public async Task CreateSavesUserToRepository()
    {
        // Arrange
        var request = _fixture.Create<CreateUser>();
        var fakeUserRepository = A.Fake<IRepository<User>>();
        var controller = new UserController(fakeUserRepository);

        // Act
        await controller.Create(request);

        // Assert
        A.CallTo(() => fakeUserRepository.Create(A<User>.That.Matches(x =>
                x.Name == request.Name)))
            .MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task ChangeNameUpdatesUserAndSavesToRepository()
    {
        // Arrange
        var user = _fixture.Create<User>();
        var fakeUserRepository = A.Fake<IRepository<User>>();
        A.CallTo(() => fakeUserRepository.GetById(user.Id))
            .Returns(user);
        
        var request = _fixture.Create<ChangeUserName>();
        var controller = new UserController(fakeUserRepository);

        // Act
        await controller.ChangeName(user.Id, request);

        // Assert
        A.CallTo(() => fakeUserRepository.Update(A<User>.That.Matches(x =>
                x == user && x.Name == request.Name)))
            .MustHaveHappenedOnceExactly();
    }
}