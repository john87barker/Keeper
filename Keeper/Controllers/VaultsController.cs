using System;
using System.Collections.Generic;
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
    public class VaultsController : ControllerBase
    {
    private readonly VaultsService _vaultsService;
    private readonly KeepsService _keepsService;

    public VaultsController(VaultsService vaultsService, KeepsService keepsService)
    {
      _vaultsService = vaultsService;
      _keepsService = keepsService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetByIdAsync(int id)
    {
        try
        {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Vault vault = _vaultsService.GetById(id, userInfo?.Id );
        return Ok(vault);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}/keeps")]
    [Authorize]
    public async Task<ActionResult<List<VaultKeepViewModel>>> GetKeeps(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          List<VaultKeepViewModel> keeps = _keepsService.GetMyKeeps(id);
          return Ok(keeps);
      }
      catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
        try
        {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newVault.CreatorId = userInfo.Id;
        Vault vault = _vaultsService.Create(newVault);
        return Ok(vault);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit([FromBody] Vault editedV, int id)
    {
        try
        {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        editedV.CreatorId = userInfo.Id;
        editedV.Id = id;
            Vault keep = _vaultsService.Edit(editedV);
            return Ok(keep);
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
            _vaultsService.Delete(id, userInfo.Id);
            return Ok("Death has been given to this keep.");
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
  }
}