using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.VariationListDto
{
    public class VariationsWithCategoryInfoDto
    {
        public string ProductPicture { get; set; }
        public string ProductName { get; set; }
        public int TotalData { get; set; }
        public decimal Price { get; set; }
    }
}
