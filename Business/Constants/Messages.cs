using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded { get; set; } = "Product Added Successfully";
        public static string ProductExist { get; set; } = "Product name already exist";
        public static string ProductListWithCategory { get; set; } = "Product List was brought successfully";
        public static string ProductNotExist { get; set; } = "Product Does not exist";
    }
}
