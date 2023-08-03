using System;
using AutoMapper;
using MVM.CabanasDream.BussinesLogic.Dtos.Requests;
using MVM.CabanasDream.BussinesLogic.Models;
using MVM.CabanasDream.BussinesLogic.Repositories;
using MVM.CabanasDream.BussinesLogic.Services.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;

namespace MVM.CabanasDream.BussinesLogic.Services;

public class CatalogoService : ICatalogoService
{
    private readonly ITemaRepository _repository;
    private readonly IMapper _mapper;

    public CatalogoService(ITemaRepository temaRepository, IMapper mapper)
    {
        _repository = temaRepository;
        _mapper = mapper;
    }

    public async Task<Tema> ObterTemaPorId(Guid id)
    {
        var tema = await _repository.ObterTemaPorId(id);

        if (tema == null)
            throw new DomainException("Tema informado não encontrado.");

        return tema;
    }

    public async Task<IEnumerable<Tema>> ObterTodosTemas()
    {
        return await _repository.ObterTodosTemas();
    }

    public async Task<Tema> AdicionarTema(TemaDto request)
    {
        var tema = new Tema(request.Nome, request.Imagem);

        await _repository.AdicionarTema(tema);
        await _repository.UnityOfWork.Commit();

        return tema;
    }

    public async Task<Tema> AdicionarItemAoTema(Guid temaId, ItemDto request)
    {
        var tema = await _repository.ObterTemaPorId(temaId);

        if (tema == null)
        {
            throw new DomainException("Tema informado não encontrado.");
        }

        var item = new Item(request.ObjetoFesta, request.Quantidade);
        item.Tema = tema;
        item.TemaId = tema.Id;

        tema.AdicionarItem(item);

        await _repository.AtualizarTema(tema);
        await _repository.UnityOfWork.Commit();

        return tema;
    }

    public void Dispose()
    {
        _repository.Dispose();
    }

}

