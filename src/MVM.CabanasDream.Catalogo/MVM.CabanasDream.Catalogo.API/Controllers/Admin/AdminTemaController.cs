//using System;
//using Microsoft.AspNetCore.Mvc;
//using MVM.CabanasDream.BussinesLogic.Dtos.Requests;
//using MVM.CabanasDream.BussinesLogic.Services.Interfaces;
//using MVM.CabanasDream.Core.Domain.Results;

//namespace MVM.CabanasDream.API.Controllers.Admin;

//[ApiController]
//[Route("admin/tema")]
//public class AdminTemaController : Controller
//{
//    private readonly IEstoqueService _estoqueService;

//    public AdminTemaController(IEstoqueService estoqueService)
//    {
//        _estoqueService = estoqueService;
//    }

//    [HttpGet("buscar")]
//    public async Task<IActionResult> ListarTodosTemas()
//    {
//        try
//        {
//            var temas = await _estoqueService.BuscarTodosTemas();
//            return Ok(BaseResult.OkResult(temas));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpGet("buscar/{id}")]
//    public async Task<IActionResult> ObterTemaPorId(Guid id)
//    {
//        try
//        {
//            var tema = await _estoqueService.BuscarTema(id);
//            return Ok(BaseResult.OkResult(tema));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpPost("adicionar")]
//    public async Task<IActionResult> CriarNovoTema([FromBody] TemaDto request)
//    {
//        try
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(BaseResult.BadResult(null));

//            var result = await _estoqueService.AdicionarNovoTema(request);
//            return Ok(BaseResult.OkResult(result));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpPatch("atualizar/status/{id}")]
//    public async Task<IActionResult> AtualizarStatus(Guid id, bool status)
//    {
//        try
//        {
//            var tema = await _estoqueService.AtualizarDisponibilidadeTema(id, status);
//            return Ok(BaseResult.OkResult(tema));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpPatch("atualizar/imagem/{id}")]
//    public async Task<IActionResult> AtualizarImagem(Guid id, string novaImagem)
//    {
//        try
//        {
//            var tema = await _estoqueService.AtualizarImagem(id, novaImagem);
//            return Ok(BaseResult.OkResult(tema));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpDelete("remover/{id}")]
//    public async Task<IActionResult> RemoverTema(Guid id)
//    {
//        try
//        {
//            await _estoqueService.RemoverTema(id);
//            return Ok(BaseResult.OkResult(null));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//}

