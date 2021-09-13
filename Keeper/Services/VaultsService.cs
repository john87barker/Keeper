using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal Vault GetById(int id, string userId)
    {
      Vault vault = _repo.GetById(id);
      if (vault == null )
      {
        throw new Exception("Invalid Id");
      }
      if((userId != vault.CreatorId && vault.IsPrivate == true))
      {
        // is the owner this person
        throw new Exception("Invalid Id");
      }
      return vault;
    }

    internal List<Vault> GetVaultsByProfile(string id, string userId, bool isPrivate = true)
    {

      List<Vault> vaults = _repo.GetVaultsByProfile(id);
      if(userId == id)
      {
        return vaults;
      }
      if (isPrivate)
      {
        vaults = vaults.FindAll(v => v.IsPrivate != true);
      }
      return vaults;

      //  if((userId != vaults.CreatorId && vaults.IsPrivate == true))
      // {
      //   // is the owner this person
      //   throw new Exception("Invalid Id");
      // }
      // return vaults;


      // List<Vault> vaults = _repo.GetVaultsByProfile(id);
      // if (careIfPrivate)
      // {
      //   vaults = vaults.FindAll(v => v.IsPrivate == true);
      // }
      // return vaults;


      //  return _repo.GetVaultsByProfile(id);
    }
    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }
    internal Vault Edit(Vault editedV)
    {
      Vault original = _repo.GetById(editedV.Id);
      if (original == null )
      {
        throw new Exception("Invalid Id");
      }
      if (original.CreatorId != editedV.CreatorId)
      {
        throw new Exception("No touching that!");
      }
      // original.Name = editedV.Name ?? original.Name;
      original.Name = editedV.Name != null && editedV.Name.Length > 0 ? editedV.Name : original.Name;

      original.Description = editedV.Description ?? original.Description;
      original.Img = editedV.Img ?? original.Img;
      original.IsPrivate = editedV.IsPrivate != null ? editedV.IsPrivate : original.IsPrivate;
      _repo.Edit(original);
      return original;
    }



    internal void Delete(int id, string userId)
    {
      Vault toDelete = GetById(id, userId);
      if (toDelete.CreatorId != userId)
      {
        throw new Exception("No deleting for you!");
      }
      _repo.Delete(id);
    }
  }
}
