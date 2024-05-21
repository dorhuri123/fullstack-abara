using BackendAbara.Models;
using Microsoft.AspNetCore.Mvc;
using BackendAbara.Services;
using Microsoft.AspNetCore.Authorization;

namespace BackendAbara.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly PetService _PetService;
    public PetController(PetService petService) =>
     _PetService = petService;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pet newPet)
    {
        await _PetService.CreateAsync(newPet);

        return CreatedAtAction(nameof(Post), new { id = newPet.Id }, newPet);
    }

}
