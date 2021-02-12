using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class VariantPicture:IEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int VariantId { get; set; }
        public Variation Variation  { get; set; }
    }
}
