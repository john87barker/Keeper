using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vkService;

    public VaultKeepsController(VaultKeepsService vkService)
    {
      _vkService = vkService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVK)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newVK.CreatorId = userInfo.Id;
        VaultKeep vk = _vkService.Create(newVK);
        return Ok(newVK);

      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vkService.Delete(id, userInfo.Id);
        return Ok("deleting this vk");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}