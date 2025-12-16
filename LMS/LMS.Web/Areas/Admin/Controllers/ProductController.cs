using Cortex.Mediator;
using LMS.Application.Features.Inventory.Commands;
using LMS.Domain.Entities;
using LMS.Web.Areas.Admin.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductController(ILogger<ProductController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var NewProduct = _mapper.Map<ProductAddCommand>(model);
                    var Result =await _mediator.SendCommandAsync<ProductAddCommand, Product>(NewProduct);
                }
                catch (Exception ex)
                {

                }
            }
            return View();
        }
    }
}
