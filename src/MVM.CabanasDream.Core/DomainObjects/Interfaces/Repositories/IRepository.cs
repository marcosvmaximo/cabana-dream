using System;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Core.Domain.Interfaces;

namespace MVM.CabanasDream.Core.Domain.Interfaces.Repositories;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    public IUnityOfWork UnityOfWork { get; }
}

