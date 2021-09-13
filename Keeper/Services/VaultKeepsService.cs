using System;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkrepo;
    private readonly VaultsService _vaultsService;

    public VaultKeepsService(VaultKeepsRepository vkrepo, VaultsService vaultsService)
    {
      _vkrepo = vkrepo;
      _vaultsService = vaultsService;
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
    internal VaultKeep Create(VaultKeep newVK, string userId)
    {
      // TODO the newVK.vaultId needs to match a vaultId on the users vaults... 
      Vault foundV = _vaultsService.GetById(newVK.VaultId, userId);
      if(userId != foundV.CreatorId)
      {
        throw new Exception("you can't do that");
      }
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