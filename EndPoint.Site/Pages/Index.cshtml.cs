using DotNetProject.Application.DTOs;
using DotNetProject.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Site.Pages
{
    public class IndexModel : PageModel
    {
        public AddNewProductDto Command;
        public List<AddNewProductDto> Products;
        private readonly IAddNewProductService _addNewProductService;

        public IndexModel(IAddNewProductService addNewProductService)
        {
            _addNewProductService = addNewProductService;
        }

        public void OnGet(int id)
        {
            Command = _addNewProductService.GetDetails(id);
            Products = _addNewProductService.GetList();
        }

        public IActionResult OnPost(AddNewProductDto command)
        {
            var result = _addNewProductService.Create(command);
            return RedirectToPage("./Index");
        }

        public void OnGetEdit(int id)
        {
            Command = _addNewProductService.GetDetails(id);
        }

        public IActionResult OnPostEdit(AddNewProductDto command)
        {
            var result = _addNewProductService.Edit(command);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDelete(int id)
        {
            var result = _addNewProductService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}