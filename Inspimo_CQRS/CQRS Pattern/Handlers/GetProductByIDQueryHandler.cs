using Inspimo_CQRS.CQRS_Pattern.Queries;
using Inspimo_CQRS.CQRS_Pattern.Results;
using Inspimo_CQRS.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inspimo_CQRS.CQRS_Pattern.Handlers
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIDQueryResult Hadle(GetProductByIDQuery query) 
        {
            var values = _context.Products.Find(query.Id);
            return new GetProductByIDQueryResult
            {
                ProductBrand = values.ProductBrand,
                ProductID = values.ProductID,
                ProductName = values.ProductName,
            };
        }
    }
}
