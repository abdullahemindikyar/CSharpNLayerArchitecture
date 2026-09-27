using NLayerArch.BussinessLayer.Abstract;
using NLayerArch.DataAccessLayer.Abstract;
using NLayerArch.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // DAL içindeki metotlarımı CategoryManager içindeki metotlarla eşleştiriyorum.Yani CategoryManager içindeki metotlarımın içi boş olacak ve DAL içindeki metotları çağıracak.
        // Data Access Layer'daki metotlarımı Business Layer'daki metotlarla eşleştirmiş oluyorum.
        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }
        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }
        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);
        }
        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
