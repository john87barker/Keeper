using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal List<VaultKeep> GetAll()
    // {
    //   string sql = @"
    //   SELECT
    //     a.*,
    //     vk.*
    //   FROM vaultKeeps vk
    //   JOIN accounts a ON a.id = vk.creatorId
    //   ";
    //   return _db.Query<Profile, VaultKeep, VaultKeep>(sql, (p, vk) =>
    //   {
    //     vk.CreatorId = p.Id;
    //     return vk;
    //   }, splitOn: "id").ToList();
    // }

 internal VaultKeep GetById(int id)
    {
      string sql = @"
      SELECT 
        a.*,
        vk.*
      FROM vaultKeeps vk
      JOIN accounts a ON a.id = vk.creatorId
      WHERE vk.id = @id;";
      // return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });

      return _db.Query<Profile, VaultKeep, VaultKeep>(sql, (p, vk) =>
      {
        vk.CreatorId = p.Id;
        return vk;
      }, new {id}, splitOn:"id").FirstOrDefault();
    }
    internal VaultKeep Create(VaultKeep newVK)
    {
      string sql = @"
      INSERT INTO vaultKeeps 
      (keepId, vaultId, creatorId) 
      VALUES 
      (@KeepId, @VaultId, @CreatorId); 
      SELECT LAST_INSERT_ID();";
      newVK.Id = _db.ExecuteScalar<int>(sql, newVK);
      return newVK;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultKeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

   
  }
}