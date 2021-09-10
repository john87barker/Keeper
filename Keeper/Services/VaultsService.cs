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

    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }
  }
}