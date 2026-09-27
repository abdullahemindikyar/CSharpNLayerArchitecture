using NLayerArch.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.BussinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        // Define generic service methods for CRUD operations
        // DAL'den gelen metotların karışmaması için başına T harfi ekledik.
        // T harfi, bu metodun generic olduğunu ve T tipinde bir entity ile çalıştığını belirtir.
        // DataAccessLayer'a doğrudan erişim sağlamak yerine, BussinessLayer üzerinden erişim sağlanır.
        // Böylece bir köprü görevi görmüş olur.
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        List<T> TGetAll();
        T TGetById(int id);
    }
}
