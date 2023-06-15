using Inspimo_CQRS.CQRS_Pattern.Commands;
using Inspimo_CQRS.DAL;

namespace CQRS.CQRS.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand command)
        {
            var values = _context.Products.Find(command.ProductID);

            values.ProductName = command.ProductName;
            values.ProductBrand = command.ProductBrand;
            values.ProductStatus = true;
            values.ProductPrice = command.ProductPrice;
            values.ProductStock = command.ProductStock;

            _context.SaveChanges();
        }
    }
}