using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
  private readonly VaultsService _vaultsService;

    public KeepsService(KeepsRepository repo, VaultsService vaultsService)
    {
      _repo = repo;
      _vaultsService = vaultsService;
    }

      internal List<Keep> GetAll()
    {
      return _repo.GetAll();
    }
    // internal List<VaultKeepViewModel> GetVaultKeeps(int id, string userId)
    // {
    //   // List<Vault> foundVs = _vaultsService.GetVaultsByProfile(userId, userId);
    //   // if(userId == userId)
    //   // {
    //   // foundVs.FindAll(v => v != userId);
    //   // }
    //   List<VaultKeepViewModel> keeps = _repo.GetVaultKeeps(id);
    //   return keeps;
    //   // return _repo.GetVaultKeeps(id);
    // }
    
     internal Keep GetById(int id)
    {
      Keep found = _repo.GetById(id);
      if(found == null)
      {
        throw new Exception("Invalid Id");
      }
      
      // TODO call to keeps repo and increase keep count
      return found;
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal Keep Edit(Keep editedK)
    {
      Keep original = GetById(editedK.Id);
      if( original.CreatorId != editedK.CreatorId)
      {
        throw new Exception("No touching that!");
      }
      original.Name = editedK.Name ?? original.Name;
      original.Description = editedK.Description ?? original.Description;
      original.Img = editedK.Img ?? original.Img;
      _repo.Edit(original);
      return original;
    }

    internal List<VaultKeepViewModel> GetKeepsByProfile(string id)
    {
      return _repo.GetKeepsByProfile(id);
    }

    internal void Delete(int id, string userId)
    {
      Keep toDelete = GetById(id);
      if(toDelete.CreatorId != userId)
      {
        throw new Exception("No deleting for you!");
      }
      _repo.Delete(id);
    }
  }
}