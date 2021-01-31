using Enities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class ProductTag:IEntity
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Product Product { get; set; }
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
        public int ProductId { get; set; }
    }
}
