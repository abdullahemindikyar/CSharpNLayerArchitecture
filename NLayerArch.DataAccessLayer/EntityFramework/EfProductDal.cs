using NLayerArch.DataAccessLayer.Abstract;
using NLayerArch.DataAccessLayer.Context;
using NLayerArch.DataAccessLayer.Repositories;
using NLayerArch.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Object> GetProductWithCategory()
        {
            var context = new DataContext();
            var values = context.Products.Select(p => new 
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductStock = p.ProductStock,
                ProductPrice = p.ProductPrice,
                CategoryName = p.Category.CategoryName
            }).ToList();

            return values.Cast<Object>().ToList();
        }
    }
}
