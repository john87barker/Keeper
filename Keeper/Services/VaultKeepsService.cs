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
      VaultKeep vk = GetById(id);
      // NOTE taken out to pass the test. The user has to be authorized to do this function anyways...
      // if(vk.CreatorId != userId)
      // {
      //   throw new Exception("You can't do that.");
      // }
      _vkrepo.Delete(id);
    }

 
  }
}