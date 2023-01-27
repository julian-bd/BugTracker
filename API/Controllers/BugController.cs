using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BugController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Bug> Get()
    {
        return new List<Bug>();
    }
}