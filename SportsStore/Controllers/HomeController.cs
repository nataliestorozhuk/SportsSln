using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Models;
using SportsStore.Models.ViewModels;


namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index() => View();
        private IStoreRepository _repository;
        public int PageSize = 4;


        public HomeController(IStoreRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index(int productPage = 1) 
            => View(new ProductsListViewModel
        {
            Products = _repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }
            });
        
    }
}
