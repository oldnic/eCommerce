using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Models {
    public class Product {
        public string Id { get; set; }

        [DisplayName("Product Name")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }        
        
        [Range(0, 10000)]
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product() {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
