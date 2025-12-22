using Cortex.Mediator;
using LMS.Application.Features.Inventory.Commands;
using LMS.Application.Features.Inventory.Queries;
using LMS.Domain;
using LMS.Domain.Entities;
using LMS.Infrastructure.Extensions;
using LMS.Web.Areas.Admin.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Product Created Successfully",
                        Type = ResponseTypes.Success
                    });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", "Failed to create Product");
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to create Product",
                        Type = ResponseTypes.Denger
                        
                    });
                }
            }
            return View();
        }
        [HttpPost]
        public JsonResult GetProductsJsonData([FromBody] ProductListModel model)
        {
            try
            {
                var query = new GetProductsQuery();
                query.SearchText = model.Search.Value;
                query.SortOrder = model.FormatSortExpression("Name", "Description", "Price", "IsAvailable");
                query.PageSize = model.PageSize;
                query.PageIndex = model.PageIndex;

                var (items,total,totalDisplay) = _mediator.SendQueryAsync<GetProductsQuery, (IList<Product>, int total, int totalDisplay)>(query).Result;

                var products = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from item in items
                            select new string[]
                            {
                                HttpUtility.HtmlEncode(item.Name),
                                HttpUtility.HtmlEncode(item.Description),
                                item.Price.ToString(),
                                item.IsAvailable.ToString(),
                                item.Id.ToString()
                            }).ToArray()
                };
                return Json(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product data");
                return Json(DataTables.EmptyResult);
                
            }
        }
    }
}