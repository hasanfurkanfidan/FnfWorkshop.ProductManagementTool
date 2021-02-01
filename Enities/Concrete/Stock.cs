using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class Stock:IEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public Application Application { get; set; }
        public int ApplicaitonId { get; set; }
        public Variation Variation { get; set; }
        public int VariationId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
