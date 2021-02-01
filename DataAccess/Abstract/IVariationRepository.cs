using Core.Abstract;
using Core.DataAccess.EntityFrameworkCore.Abstract;
using Enities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IVariationRepository:IGenericRepository<Variation>
    {
    }
}
