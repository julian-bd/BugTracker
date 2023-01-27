using API.Requests;
using API.Requests.User;
using Domain.DataStorage;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet("{id:guid}")]
    public Task<User> GetById(Guid id)
    {
        return _userRepository.GetById(id);
    }

    [HttpPost]
    public async Task Create([FromBody] CreateUser request)
    {
        var user = new User(request.Name);
        await _userRepository.Create(user);
    }
    
    [HttpPut]
    public async Task Update([FromBody] UpdateUser request)
    {
        await _userRepository.Update(request.User);
    }
}