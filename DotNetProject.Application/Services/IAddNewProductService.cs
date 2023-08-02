using DotNetProject.Application.DTOs;

namespace DotNetProject.Application.Services
{
    public interface IAddNewProductService
    {
        ResultDto Create(AddNewProductDto entity);
        ResultDto Edit(AddNewProductDto entity);
        ResultDto Delete(int id);
        List<AddNewProductDto> GetList();
        AddNewProductDto GetDetails(int id);
    }
}
