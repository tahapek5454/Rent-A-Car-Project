using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        // nesne icin validation yani dogrulama kuralları
        //FluentValidation paketinden inherit ettik

        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();

            RuleFor(c => c.ColorId).NotEmpty();

            RuleFor(c => c.ModelYear).GreaterThan(1996);

            RuleFor(c => c.Description).MinimumLength(2);  // desciripton minumum 2 karakter

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);    // Boyle Boyle ekleriz
            // when ile kosul da belirlenebilir
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 2);

            //Not kendin de kural yazabilirisin Must kullanırsın kuralı bool fonksiyon ile belitirsin
        }

    }
}
