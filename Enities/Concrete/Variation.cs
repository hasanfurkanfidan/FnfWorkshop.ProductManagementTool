using Enities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class Variation:IEntity
    {
        public int Id { get; set; }

        public Application Application { get; set; }
        public int ApplicationId { get; set; }
        public VariationType VariationType { get; set; }
        public int VariationTypeId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public List<Stock> Stocks { get; set; }

    }
}
