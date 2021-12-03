using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Activity>>> GetActivities()
    {
        return Ok(await Mediator.Send(new ActivityList.Query()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
        return Ok(await Mediator.Send(new ActivityDetails.Query(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Activity activity)
    {
        return Ok(await Mediator.Send(new ActivityCreate.Command(activity)));
    }

}
