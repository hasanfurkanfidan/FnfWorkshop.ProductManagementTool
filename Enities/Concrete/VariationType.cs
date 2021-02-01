using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class VariationType:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
        public List<Variation> Variations { get; set; }
    }
}
