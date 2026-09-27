using NLayerArch.DataAccessLayer.Abstract;
using NLayerArch.DataAccessLayer.Repositories;
using NLayerArch.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.DataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        
    }
}
