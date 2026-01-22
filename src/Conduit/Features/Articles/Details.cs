using System.Net;

using System.Threading.Tasks;
using Conduit.Infrastructure;
using Conduit.Infrastructure.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Features.Articles;

public class Details
{
    public record Query(string Slug) : IRequest<ArticleEnvelope>;

    public class QueryValidator
    {
        public QueryValidator()
        {
        }
    }

    public class QueryHandler(ConduitContext context) : IRequestHandler<Query, ArticleEnvelope>
    {
        public async Task<ArticleEnvelope> Handle(
            Query message,
            CancellationToken cancellationToken
        )
        {
            var article = await context
                .Articles.GetAllData()
                .FirstOrDefaultAsync(x => x.Slug == message.Slug, cancellationToken);

            if (article == null)
            {
                throw new RestException(
                    HttpStatusCode.NotFound,
                    new { Article = Constants.NOT_FOUND }
                );
            }
            return new ArticleEnvelope(article);
        }
    }
}
