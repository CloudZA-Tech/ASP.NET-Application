using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Features.Profiles;

[Route("profiles")]
public class ProfilesController : Controller
{
    private readonly ISender _mediator;

    public ProfilesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{username}")]
    public Task<ProfileEnvelope> Get(string username, CancellationToken cancellationToken) =>
        _mediator.Send(new Details.Query(username), cancellationToken);
}
