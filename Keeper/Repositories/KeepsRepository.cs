using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

// TODO Passing all but one of the get vaultkeeps: Array contains keeps | AssertionError: Returned array does not contain newly created keep, Make Sure you can successfully Post Keeps: expected undefined to be an object
// TODO also need to pass the no auth get tests as well.
// NOTE I can post keeps but it isn't taking a keep into the system I believe
     internal List<VaultKeepViewModel> GetVaultKeeps(int id)
    {
      string sql = @"
      SELECT
        a.*,
        k.*,
        vk.id AS vaultKeepsId
        FROM vaultKeeps vk
        JOIN keeps k ON vk.vaultId = k.id
        JOIN accounts a ON a.id = k.creatorId
        WHERE vk.vaultId = @id;
      ";
      return _db.Query<Profile, VaultKeepViewModel, VaultKeepViewModel>(sql, (p, vk) =>
      {
        vk.Creator = p;
        return vk;
      }, new {id}, splitOn: "id").ToList();
    }
     internal List<Keep> GetAll()
    {
      string sql = @"
      SELECT
        a.*,
        k.*
        FROM keeps k
        JOIN accounts a ON a.id = k.creatorId
      ";
      return _db.Query<Profile, Keep, Keep>(sql, (p, k) =>
      {
        k.Creator = p;
        return k;
      }, splitOn: "id").ToList();
    }

    internal List<VaultKeepViewModel> GetKeepsByProfile(string id)
    {
      string sql = @"
      SELECT
        a.*,
        k.*
        FROM keeps k
        JOIN accounts a ON a.id = k.creatorId
        WHERE k.creatorId = @id;
        
      ";
      return _db.Query<Profile, VaultKeepViewModel, VaultKeepViewModel>(sql, (p, vk) =>
      {
        vk.Creator = p;
        return vk;
      }, new {id}, splitOn: "id").ToList();    }

    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT
      a.*,
      k.*
      FROM keeps k
      JOIN accounts a on a.id = k.creatorId
      WHERE k.id = @id;
      ";
      return _db.Query<Profile, Keep, Keep>(sql, (p, k) =>
      {
        k.Creator = p;
        return k;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (name, description, img, views, shares, keeps, creatorId)
      VALUES
      (@Name, @Description, @Img, @Views, @Shares, @Keeps, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return GetById(newKeep.Id);
      //   return newKeep;
    }

    internal Keep Edit(Keep updatedData)
    {
      string sql = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        img = @Img
      WHERE id = @id
      ";
      _db.Execute(sql, updatedData);
      return updatedData;
    }
   
    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}