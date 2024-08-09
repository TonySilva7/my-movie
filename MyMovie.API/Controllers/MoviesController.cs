using Microsoft.AspNetCore.Mvc;
using MyMovie.Application.UseCases;
using MyMovie.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyMovie.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    // GET: api/<MoviesController>
    [HttpGet]
    public async Task< IActionResult> Get([FromServices] IMovieUseCase movieUseCase)
    {
        IEnumerable<Movie> movies = await movieUseCase.Execute();

        return Ok(movies);
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<MoviesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
