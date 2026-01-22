
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Features.Tags;

[Route("tags")]
public class TagsController(MediatR.IMediator mediator) : Controller
{
    [HttpGet]
    public Task<TagsEnvelope> Get(CancellationToken cancellationToken) =>
        mediator.Send(new List.Query(), cancellationToken);
}
