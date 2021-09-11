using System;
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
