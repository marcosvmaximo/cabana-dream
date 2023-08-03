using System;
namespace MVM.CabanasDream.Core.Data.Interfaces;

public interface IUnityOfWork
{
    Task<bool> Commit();
}

