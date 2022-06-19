using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zadaniedodatkowe.DTOs;
using zadaniedodatkowe.Entities.Models;
using zadaniedodatkowe.Services;

namespace zadaniedodatkowe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IDatabaseService _service;

        public GamesController(IDatabaseService service)
        {
           _service = service;
        }

        [HttpPost("companies")]
        public async Task<IActionResult> AddGameToCompany(GamePost body)
        {
            if(!ModelState.IsValid){
                return BadRequest("Bledne dane");
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)){
                try{
                    var game = new Game
                    {
                        Name = body.Name,
                        ReleaseDate = body.ReleaseDate,
                        Description = body.Description
                    };
                    await _service.Create(game);
                    await _service.SaveChanges();

                    foreach (var gameCompany in body.Companies){
                        if(await _service.GetCompanyById(gameCompany.IdCompany).FirstOrDefaultAsync().ConfigureAwait(false) is null){
                            return NotFound($"Nie znaleziono firmy z ID: {gameCompany.IdCompany}");
                        }

                        await _service.Create(new GameCompany
                        {
                            IdGame = game.IdGame,
                            IdCompany = gameCompany.IdCompany
                        });
                    }

                    scope.Complete();
                    
                }catch(Exception){
                    return Problem("Blad serwera");
                }
            }
            await _service.SaveChanges();

            return NoContent();
        }
    }
}