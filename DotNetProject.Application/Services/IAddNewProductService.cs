using DotNetProject.Application.DTOs;

namespace DotNetProject.Application.Services
{
    public interface IAddNewProductService
    {
        ResultDto Create(AddNewProductDto entity);
        ResultDto Update(AddNewProductDto entity, int id);
        ResultDto Delete(int id);
        List<AddNewProductDto> GetList();
    }
}
