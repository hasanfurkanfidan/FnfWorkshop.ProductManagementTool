using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class Application:IEntity
    {
        //Hepsiburada 
        // 2 
        public int Id { get; set; }
        public string AppName { get; set; }
        public List<Product> Products { get; set; }
        public List<Variation> Variations { get; set; }
        public List<ProductTag> ProductTags { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<VariationType>VariationTypes { get; set; }
        public List<Category> Categories { get; set; }
    }
}
