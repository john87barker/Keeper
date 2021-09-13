using System;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkrepo;

    public VaultKeepsService(VaultKeepsRepository vkrepo)
    {
      _vkrepo = vkrepo;
    }

   private VaultKeep GetById(int id)
    {
      VaultKeep found = _vkrepo.GetById(id);
      if (found == null)
      {
        throw new Exception("invalid id given");
      }
      return found;
    }
    internal VaultKeep Create(VaultKeep newVK)
    {
    return _vkrepo.Create(newVK);
    }

    internal void Delete(int id, string userId)
    {
      VaultKeep found = GetById(id);
// TODO this needs to work on the authorized test. Not sure why it isn't.
      if(found.CreatorId != userId)
      {
        throw new Exception("You can't do that.");
      }
      _vkrepo.Delete(id);
    }

 
  }
}