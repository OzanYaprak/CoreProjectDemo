using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri adı boş geçilemez");
            RuleFor(x => x.CustomerCity).NotEmpty().WithMessage("Müşteri şehir bilgisi boş geçilemez");
        }
    }
}
