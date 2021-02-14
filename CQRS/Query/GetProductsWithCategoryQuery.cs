using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Query
{
    public class GetProductsWithCategoryQuery
    {
        public string CategoryName { get; set; }
        public int ApplicationId { get; set; }
    }
}
