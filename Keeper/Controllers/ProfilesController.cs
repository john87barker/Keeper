using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
  [ApiController]
    [Route("/api/[controller]")]
    // [Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _acs;
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;

        public ProfilesController(AccountService acs, KeepsService keepsService, VaultsService vaultsService)
        {
            _acs = acs;
      _keepsService = keepsService;
      _vaultsService = vaultsService;
    } 

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile prof = _acs.GetProfileById(id);
        return prof;
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public ActionResult<List<VaultKeepViewModel>> GetKeeps(string id)
    {
      try
      {
        List<VaultKeepViewModel> keeps = _keepsService.GetKeepsByProfile(id);
        return keeps;
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

     [HttpGet("{id}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaults(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Vault> vaults = _vaultsService.GetVaultsByProfile(id, userInfo?.Id);
        return vaults;
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    }
}