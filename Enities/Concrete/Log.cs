using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class Log:IEntity
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Urgency { get; set; }
    }
}
