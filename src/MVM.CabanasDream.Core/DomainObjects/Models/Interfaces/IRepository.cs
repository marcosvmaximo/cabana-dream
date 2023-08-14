using System;
using MVM.CabanasDream.Core.Data.Interfaces;

namespace MVM.CabanasDream.Core.Domain.Models;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    public IUnityOfWork UnityOfWork { get; }
}

