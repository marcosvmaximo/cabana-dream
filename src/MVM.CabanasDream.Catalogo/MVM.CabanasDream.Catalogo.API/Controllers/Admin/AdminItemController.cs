//using System;
//using Microsoft.AspNetCore.Mvc;
//using MVM.CabanasDream.BussinesLogic.Dtos.Requests;
//using MVM.CabanasDream.BussinesLogic.Enum;
//using MVM.CabanasDream.BussinesLogic.Services.Interfaces;
//using MVM.CabanasDream.Core.Domain.Results;

//namespace MVM.CabanasDream.API.Controllers.Admin;

//[ApiController]
//[Route("admin/item")]
//public class AdminItemController : Controller
//{
//    private readonly IEstoqueService _estoqueService;

//    public AdminItemController(IEstoqueService estoqueService)
//    {
//        _estoqueService = estoqueService;
//    }

//    [HttpGet("buscar")]
//    public async Task<IActionResult> ListarTodosItems()
//    {
//        try
//        {
//            var items = await _estoqueService.BuscarTodosItems();
//            return Ok(BaseResult.OkResult(items));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpGet("buscar/objeto")]
//    public async Task<IActionResult> BuscarItem([FromQuery] EObjetoDeFesta request)
//    {
//        try
//        {
//            var item = await _estoqueService.BuscarItemPorObjeto(request);
//            return Ok(BaseResult.OkResult(item));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpPost("incrementar")]
//    public async Task<IActionResult> IncrementarItem([FromBody] ItemDto request)
//    {
//        try
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(BaseResult.BadResult(null));

//            var item = await _estoqueService.IncrementarItem(request);
//            return Ok(BaseResult.OkResult(item));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }

//    [HttpPatch("decrementar")]
//    public async Task<IActionResult> DecrementarItem(ItemDto request)
//    {
//        try
//        {
//            var result = await _estoqueService.DecrementarItem(request);
//            return Ok(BaseResult.OkResult(result));
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(BaseResult.BadResult(ex.Message));
//        }
//    }
//}

