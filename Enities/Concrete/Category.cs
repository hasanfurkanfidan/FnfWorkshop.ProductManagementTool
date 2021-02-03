using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Concrete
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        //Parent
        public Category ParentGategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
