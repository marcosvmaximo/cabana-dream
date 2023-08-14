using MediatR;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;
using MVM.CabanasDream.Fiscal.API.Interfaces;

namespace MVM.CabanasDream.Fiscal.API.Events
{
    public class PagamentoEventHandler :
        INotificationHandler<PagamentoRealizadoEvent>,
        INotificationHandler<PagamentoRecusadoEvent>
    {
        private readonly IFiscalService _service;

        public PagamentoEventHandler(IFiscalService service)
        {
            _service = service;
        }

        public async Task Handle(PagamentoRealizadoEvent message, CancellationToken cancellationToken)
        {
            // Confirmar vigencia do contrato.
            // .
            //await _service.ConfimarContrato();
        }

        public async Task Handle(PagamentoRecusadoEvent message, CancellationToken cancellationToken)
        {
            // Quebrar contrato, pagamento falhado...
            await _service.QuebrarContrato();
        }
    }
}

