﻿using CQRS.CQRS.Handlers;
using Inspimo_CQRS.CQRS_Pattern.Commands;
using Inspimo_CQRS.CQRS_Pattern.Handlers;
using Inspimo_CQRS.CQRS_Pattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Inspimo_CQRS.Controllers
{
    public class Default : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly GetProductByIDQueryHandler _getProductByIDQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductUpdateByIDQueryHandler _getProductUpdateByIDQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public Default(GetProductQueryHandler getProductQueryHandler, GetProductByIDQueryHandler getProductByIDQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductUpdateByIDQueryHandler getProductUpdateByIDQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _getProductByIDQueryHandler = getProductByIDQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductUpdateByIDQueryHandler = getProductUpdateByIDQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }
        public IActionResult GetProduct(int id)
        {
            var values=_getProductByIDQueryHandler.Hadle(new GetProductByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {   
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductUpdateByIDQueryHandler.Handle(new GetProductUpdateByIDQuery(id));

            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);

            return RedirectToAction("Index");
        }
    }
}
