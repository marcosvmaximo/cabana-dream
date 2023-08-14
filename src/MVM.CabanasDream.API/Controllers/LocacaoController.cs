using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVM.CabanasDream.API.Controllers.Common;
using MVM.CabanasDream.API.Models;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Locacao.Application.Commands;

namespace MVM.CabanasDream.API.Controllers;

[ApiController]
[Route("v1/locacao")]
public class LocacaoController : BaseController
{
    public LocacaoController(
        IMediatorHandler mediator,
        INotificationHandler<DomainNotification> notificationHandler,
        IMapper mapper) : base(mediator, notificationHandler, mapper)
    {
    }

    [HttpPost("festa")]
    public async Task<IActionResult> CriarFesta([FromBody] CriarFestaRequest request)
    {
        var result = await EnviarComando<CriarFestaRequest, CriarFestaCommand>(request);

        if (result.HttpCode == (int)HttpStatusCode.OK)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPatch("festa/finalizar")]
    public async Task<IActionResult> FinalizarFesta([FromRoute] FinalizarFestaRequest request)
    {
        var result = await EnviarComando<FinalizarFestaRequest, FinalizarFestaCommand>(request);

        if (result.HttpCode == (int)HttpStatusCode.OK)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPatch("festa/cancelar")]
    public async Task<IActionResult> CancelarFesta([FromRoute] CancelarFestaRequest request)
    {
        var result = await EnviarComando<CancelarFestaRequest, CancelarFestaCommand>(request);

        if (result.HttpCode == (int)HttpStatusCode.OK)
            return Ok(result);

        return BadRequest(result);
    }

    //[HttpGet("contrato")]
    //public async Task<IActionResult> ObterContratoDeLocacao()
    //{

    //}
}

