using System;
using Microsoft.AspNetCore.Mvc;
using MVM.CabanasDream.BussinesLogic.Dtos.Requests;
using MVM.CabanasDream.BussinesLogic.Services.Interfaces;
using MVM.CabanasDream.Core.Domain.Results;

namespace MVM.CabanasDream.API.Controllers;

[ApiController]
[Route("catalogo")]
public class CatalogoController : Controller
{
    private readonly ICatalogoService _catalogoService;

    public CatalogoController(ICatalogoService catalogoService)
    {
        _catalogoService = catalogoService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTemas()
    {
        try
        {
            var temas = await _catalogoService.ObterTodosTemas();
            return Ok(BaseResult.OkResult(temas));
        }
        catch (Exception ex)
        {
            return BadRequest(BaseResult.BadResult(ex.Message));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterTemaPorId(Guid id)
    {
        try
        {
            var tema = await _catalogoService.ObterTemaPorId(id);
            return Ok(BaseResult.OkResult(tema));
        }
        catch (Exception ex)
        {
            return BadRequest(BaseResult.BadResult(ex.Message));
        }
    }

    [HttpPost("adicionar")]
    public async Task<IActionResult> AdicionarTema([FromBody] TemaDto request)
    {
        try
        {
            var tema = await _catalogoService.AdicionarTema(request);
            return Ok(BaseResult.OkResult(tema));
        }
        catch (Exception ex)
        {
            return BadRequest(BaseResult.BadResult(ex.Message));
        }
    }

    [HttpPost("adicionar/item/{id}")]
    public async Task<IActionResult> AdicionarItemAoTema([FromRoute] Guid id, [FromBody] ItemDto request)
    {
        try
        {
            var tema = await _catalogoService.AdicionarItemAoTema(id, request);
            return Ok(BaseResult.OkResult(tema));
        }
        catch (Exception ex)
        {
            return BadRequest(BaseResult.BadResult(ex.Message));
        }
    }
}