using API.Requests;
using API.Requests.Bug;
using Domain.DataStorage;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BugController : ControllerBase
{
    private readonly IRepository<Bug> _bugRepository;

    public BugController(IRepository<Bug> bugRepository)
    {
        _bugRepository = bugRepository;
    }
    
    [HttpGet]
    public Task<IEnumerable<Bug>> GetAll()
    {
        return _bugRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    public Task<Bug> GetById(Guid id)
    {
        return _bugRepository.GetById(id);
    }

    [HttpPost]
    public async Task Create([FromBody] CreateBug request)
    {
        var bug = new Bug(request.Title, request.Description);
        await _bugRepository.Create(bug);
    }
    
    [HttpPut]
    public async Task Update([FromBody] UpdateBug request)
    {
        await _bugRepository.Update(request.Bug);
    }
}
