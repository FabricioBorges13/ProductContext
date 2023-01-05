using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Application.Features.Products.Commands
{
    public class ProductUpdateCommand
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime DueDate { get; set; }
        public long IdProvider { get; set; }
        public string DescriptionProvider { get; set; }
        public string CNPJProvider { get; set; }
    }

    public class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.ManufacturingDate).LessThan(x => x.DueDate).WithMessage("Data de fabricação deve ser menor que a data de vencimento");
        }
    }
}
