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

    private Keep GetById(int id)
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

   
  }
}