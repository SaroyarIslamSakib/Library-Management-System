using System.Diagnostics;
using System.Threading.Tasks;
using Cortex.Mediator;
using LMS.Application.Features.Inventory.Commands;
using LMS.Application.Features.Inventory.Queries;
using LMS.Domain;
using LMS.Domain.Entities;
using LMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var command = new ProductAddCommand()
            {
                Name = "Laptop",
                Price = 60000,
            };
            var product = await _mediator.SendCommandAsync<ProductAddCommand, Product>(command);

            //var query = new ProductGetQuery() { Id = new Guid("33bcb694-a8d5-4789-a4e4-2a97119f91ee") };
            //var product = await _mediator.SendQueryAsync<ProductGetQuery, Product>(query);


            //var query = new ProductGetAllQuery();
            //IList<Product> products = await _mediator.SendQueryAsync<ProductGetAllQuery, IList<Product>>(query);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
