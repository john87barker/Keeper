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
     internal Keep GetById(int id)
    {
      Keep found = _repo.GetById(id);
      return found;
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal Keep Edit(Keep editedK)
    {
      Keep original = GetById(editedK.Id);
    //   if( original.CreatorId != editedK.CreatorId)
    //   {
    //     throw new Exception("No touching that!");
    //   }
      original.Name = editedK.Name ?? original.Name;
      original.Description = editedK.Description ?? original.Description;
      original.Img = editedK.Img ?? original.Img;
      _repo.Edit(original);
      return original;
    }
  }
}