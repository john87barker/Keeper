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
    public class KeepsController : ControllerBase
    {
    private readonly KeepsService _keepsService;

    public KeepsController(KeepsService keepsService)
    {
      _keepsService = keepsService;
    }

    [HttpGet]
    public ActionResult<List<Keep>> GetAll()
    {
        try
        {
        List<Keep> keeps = _keepsService.GetAll();
        return Ok(keeps);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
        try
        {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newKeep.CreatorId = userInfo.Id;
        Keep keep = _keepsService.Create(newKeep);
        return Ok(keep);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

  }
}