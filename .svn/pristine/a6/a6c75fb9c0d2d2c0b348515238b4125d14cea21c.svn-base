using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;
using Ninject;

namespace DoubleJ.Oms.Model
{
    public class UniqueAttribute : ValidationAttribute
    {
        [Inject]
        public ICustomerLocationRepository customerLocationRepository { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as CustomerLocationViewModel;

            var isExistEmail = customerLocationRepository.IsExistCustomerLocationEmail(customer.Email,
                customer.CustomerId, customer.LocationId);

            if (isExistEmail)
            {
                return new ValidationResult("This email is exist");
            }

            return null;
        }
    }
}