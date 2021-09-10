using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

      internal List<Keep> GetAll()
    {
      return _repo.GetAll();
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

  
  }
}