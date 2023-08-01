using DotNetProject.Application.DTOs;
using DotNetProject.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EndPoint.Site.Pages
{
    public class IndexModel : PageModel
    {
        public List<AddNewProductDto> Products;
        private readonly IAddNewProductService _addNewProductService;

        public IndexModel(IAddNewProductService addNewProductService)
        {
            _addNewProductService = addNewProductService;
        }

        public void OnGet()
        {
            Products = _addNewProductService.GetList();
        }

        public IActionResult OnPost(AddNewProductDto command)
        {
            var result = _addNewProductService.Create(command);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDelete(int id)
        {
            var result = _addNewProductService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}