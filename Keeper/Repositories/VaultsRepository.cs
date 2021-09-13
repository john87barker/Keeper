using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (creatorId, name, description, img, isPrivate)
      VALUE
      (@CreatorId, @Name, @Description, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID();
      ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return GetById(newVault.Id);
    }

    internal Vault GetById(int id)
    {
      string sql = @"
      SELECT
      a.*,
      v.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @id;
      ";
      return _db.Query<Profile, Vault, Vault>(sql, (p, v) =>
      {
        v.Creator = p;
        return v;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal List<Vault> GetVaultsByProfile(string id)
    {
      string sql = @"
      SELECT
        a.*,
        v.*
        FROM vaults v
        JOIN accounts a ON a.id = v.creatorId
        WHERE v.creatorId = @id;
      ";
      return _db.Query<Profile, Vault, Vault>(sql, (p, v) =>
      {
        v.Creator = p;
        return v;
      }, new {id}, splitOn: "id").ToList();
    }

    internal Vault Edit(Vault updatedData)
    {
      string sql = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @IsPrivate
      WHERE id = @id
      ";
      _db.Execute(sql, updatedData);
      return updatedData;
    }

    internal void Delete(int id)
    {
       string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}