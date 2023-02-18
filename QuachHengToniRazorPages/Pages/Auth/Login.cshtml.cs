using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuachHengToniRazorPages.DTO;
using QuachHengToniRazorPages.Helpers;
using Repo;
using System;
using System.Threading.Tasks;

namespace QuachHengToniRazorPages.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO LoginDTO { get; set; }

		private readonly ILogger<LoginModel> logger;
		private readonly IRepository<Customer> customerRepository;
        private readonly IRepository<StaffAccount> staffRepository;
        
        public LoginModel(ILogger<LoginModel> logger, IRepository<Customer> customerRepository, IRepository<StaffAccount> staffRepository)
        {
			this.logger = logger;
            this.customerRepository = customerRepository;
            this.staffRepository= staffRepository;
        }

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["StatusMessage"] = "Invalid data.";
                    return Page();
                }

                Customer customer = customerRepository.RetrieveById(LoginDTO.Email);
                if (customer != null)
                {
                    if (LoginDTO.Password != customer.CustomerPassword)
                    {
                        TempData["StatusMessage"] = "Wrong password.";
                        return Page();
                    }
                    HttpContext.Session.SetString("Role", "Customer");
                    HttpContext.Session.SetString("Email", customer.CustomerEmail);
                    //HttpContext.Session.Set<Customer>("Customer", customer);
                    return RedirectToPage("/Index");
                }
                else
                {
                    StaffAccount staff = staffRepository.RetrieveById(LoginDTO.Email);
                    logger.LogInformation($"{LoginDTO.Email} - {LoginDTO.Password} - {staff.Email} - {staff.Password}");

                    if (staff == null)
                    {
                        TempData["StatusMessage"] = "Wrong email.";
                        return Page();
                    }

                    if (LoginDTO.Password != staff.Password)
                    {
                        TempData["StatusMessage"] = "Wrong password.";
                        return Page();
                    }
                    HttpContext.Session.SetString("Role", "Staff");
                    HttpContext.Session.SetString("Email", staff.Email);
                    //HttpContext.Session.Set<StaffAccount>("Staff", staff);
                    return RedirectToPage("/Index");
                }
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
