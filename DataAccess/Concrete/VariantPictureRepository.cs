using DataAccess.Abstract;
using Enities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class VariantPictureRepository:GenericRepository<VariantPicture>,IVariantPictureRepository
    {
    }
}
