using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuachHengToniRazorPages.DTO;
using Repo;
using System;
using System.Linq;

namespace QuachHengToniRazorPages.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public CustomerRegisterDTO CustomerRegisterDTO { get; set; }

		private readonly ILogger<RegisterModel> logger;
		private readonly IRepository<Customer> customerRepository;

        public RegisterModel(ILogger<RegisterModel> logger, IRepository<Customer> customerRepository)
        {
			this.logger = logger;
            this.customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
				if (!ModelState.IsValid)
				{
                    TempData["StatusMessage"] = "Invalid data.";
                    return Page();
				}

				var customer = customerRepository.RetrieveById(CustomerRegisterDTO.CustomerEmail);
				if (customer != null)
				{
					TempData["StatusMessage"] = "Customer already exists.";
					return Page();
				}

				var lastCustomer = customerRepository.Retrieve().Skip(customerRepository.Retrieve().Count - 1).First();
				var lastCustomerIdNumber = int.Parse(lastCustomer.CustomerId.Remove(0, 1));
				var customerIdNumber = lastCustomerIdNumber + 1;
				int numbersOfZero = 5 - customerIdNumber.ToString().Count();

				customer = new Customer()
				{
					CustomerId = $"C{new string('0', numbersOfZero)}{customerIdNumber}",
					CustomerName = CustomerRegisterDTO.CustomerName,
					CustomerEmail = CustomerRegisterDTO.CustomerEmail,
					CustomerPassword = CustomerRegisterDTO.CustomerPassword,
					Mobile = CustomerRegisterDTO.Mobile,
					IdentityCard = CustomerRegisterDTO.IdentityCard,
					LicenceDate = CustomerRegisterDTO.LicenceDate,
					LicenceNumber = CustomerRegisterDTO.LicenceNumber
				};
				customerRepository.Create(customer);

				return RedirectToPage("/Index");
			} 
            catch (Exception ex) 
            {
				TempData["StatusMessage"] = $"Something went wrong.";
				logger.LogError($"Exception: {ex.Message}");
				return Page();
            }
        }
    }
}
