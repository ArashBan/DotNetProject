using DotNetProject.Application.Contexts;
using DotNetProject.Application.DTOs;
using DotNetProject.Domain.Entities;

namespace DotNetProject.Application.Services
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;

        public AddNewProductService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Create(AddNewProductDto entity)
        {
            var product = new Product(entity.Name, entity.ManufacturePhone, entity.ManufactureEmail);

            _context.Products.Add(product);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = $" کالای {product.Name} با موفقیت در دیتابیس ذخیره شد"
            };
        }

        public ResultDto Update(AddNewProductDto entity, int id)
        {
            var product = new Product(entity.Name, entity.ManufacturePhone, entity.ManufactureEmail);

            var result = GetBy(id);

            if (result != null)
            {
                product.Name = result.Name;
                product.ManufacturePhone = result.ManufacturePhone;
                product.ManufactureEmail = result.ManufactureEmail;
            }

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = $" ویرایش {product.Name} با موفقیت در دیتابیس ذخیره شد"
            };
        }

        public ResultDto Delete(int id)
        {
            var result = GetBy(id);

            result.IsAvailable = false;
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = $" حذف {result.Name} با موفقیت در دیتابیس ذخیره شد"
            };
        }

        public List<AddNewProductDto> GetList()
        {
            return _context.Products.Where(x => x.IsAvailable).Select(x => new AddNewProductDto
            {
                Id = x.Id,
                Name = x.Name,
                ManufacturePhone = x.ManufacturePhone,
                ManufactureEmail = x.ManufactureEmail
            }).ToList();
        }

        public Product GetBy(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
