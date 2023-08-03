using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVM.CabanasDream.Core.Comunications.Interfaces;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Locacao.API.Controllers.Common;
using MVM.CabanasDream.Locacao.API.Models;
using MVM.CabanasDream.Locacao.Application.Commands;

namespace MVM.CabanasDream.Locacao.API.Controllers;

[ApiController]
[Route("v1/locacao")]
public class LocacaoController : BaseController
{
    public LocacaoController(
        IMediatrHandler mediator,
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

    //[HttpPost("finalizar")]
    //public async Task<IActionResult> FinalizarFesta([FromRoute] FinalizarFestaCommand request)
    //{

    //}
    //[HttpPost("cancelar")]
    //public async Task<IActionResult> CancelarFesta([FromRoute] CancelarFestaCommand request)
    //{

    //}

    //[HttpGet("contrato")]
    //public async Task<IActionResult> ObterContratoDeLocacao()
    //{

    //}
}

