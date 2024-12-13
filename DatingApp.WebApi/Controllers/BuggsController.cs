using System;
using DatingApp.Logic.Controllers;
using DatingApp.Logic.DataContext;
using DatingApp.Logic.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.WebApi.Controllers;

public class BuggsController(ProjectDbContext dbContext) : BaseApiController
{
    Logic.Controllers.BuggsController buggsCtrl = new(dbContext);

    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetAuth()
    {
        return "secret text";
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        var thing = buggsCtrl.GetNotFound();

        return thing == null ? NotFound() : thing;
    }

    [HttpGet("server-error")]
    public ActionResult<AppUser> GetServerError()
    {
        var thing = buggsCtrl.GetServerError() ?? throw new Exception("A bad thing has happened");
        
        return thing;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("This was not a good request");
    }
}
