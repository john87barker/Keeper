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
  }
}