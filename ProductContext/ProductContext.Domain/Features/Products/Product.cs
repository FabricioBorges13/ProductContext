using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Features.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Situation { get; private set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? DueDate { get; set; }
        public long? IdProvider { get; set; }
        public string DescriptionProvider { get; set; }
        public string CNPJProvider { get; set; }

        public Product()
        {
            Situation = true;
        }

        public void Delete()
        {
            Situation = false;
        }

        public void ValidateManufacturingDate()
        {
            if (ManufacturingDate.GetValueOrDefault() >= DueDate.GetValueOrDefault())
                throw new Exception("Data de fabricação deve ser menor que a data de vencimento");
        }
    }
}
