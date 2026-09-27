using NLayerArch.DataAccessLayer.Abstract;
using NLayerArch.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        DataContext context = new DataContext();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>(); // Çağrıldığında T tipine göre DbSet'i alır ve _object değişkenine atar.
        }

        public void Delete(T entity)
        {
            var deletedEntity = context.Entry(entity); // Entity'nin durumunu alır.
            deletedEntity.State = EntityState.Deleted; // Entity'nin durumunu silinmiş olarak işaretler.
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetById(int id)
        {
            return _object.Find(id); // T tipine göre id ile entity'yi bulur ve döndürür.
        }

        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity); // Entity'nin durumunu alır.
            addedEntity.State = EntityState.Added; // Entity'nin durumunu eklenen olarak işaretler.
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
