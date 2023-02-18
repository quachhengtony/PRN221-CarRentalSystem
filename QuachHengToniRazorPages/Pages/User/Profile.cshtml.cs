using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuachHengToniRazorPages.DTO;
using QuachHengToniRazorPages.Helpers;
using QuachHengToniRazorPages.Pages.Auth;
using Repo;
using System;
using System.Text.Json;

namespace QuachHengToniRazorPages.Pages.User
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> logger;
        private readonly IRepository<StaffAccount> staffRepository;
        private readonly IRepository<Customer> customerRepository;

        [BindProperty]
        public WriteStaffAccountDTO WriteStaffAccountDTO { get; set; }

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public ProfileModel(ILogger<ProfileModel> logger, IRepository<StaffAccount> staffRepository, IRepository<Customer> customerRepository) 
        { 
            this.logger = logger;
            this.staffRepository = staffRepository;
            this.customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            if (!SessionHelper.IsSignedIn(HttpContext))
            {
                return RedirectToPage("/Auth/Login");
            }

            if (HttpContext.Session.GetString("Role") == "Staff")
            {
                StaffAccount = staffRepository.RetrieveById(HttpContext.Session.GetString("Email"));
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Staff" && !string.IsNullOrEmpty(WriteStaffAccountDTO.OldPassword))
                {
                    StaffAccount = staffRepository.RetrieveById(HttpContext.Session.GetString("Email"));

                    if (WriteStaffAccountDTO.OldPassword == null || WriteStaffAccountDTO.OldPassword != StaffAccount.Password)
                    {
                        TempData["StatusMessage"] = "Wrong password.";
                        return Page();
                    }

                    StaffAccount.Email = WriteStaffAccountDTO.Email ?? StaffAccount.Email;
                    StaffAccount.FullName = WriteStaffAccountDTO.FullName;
                    StaffAccount.Role = WriteStaffAccountDTO.Role ?? StaffAccount.Role;
                    StaffAccount.Password = WriteStaffAccountDTO.NewPassword ?? StaffAccount.Password;

                    staffRepository.Update(StaffAccount);
                }
                return RedirectToPage("./Profile");

            }
            catch (Exception ex)
            {
                logger.LogError($"Exception: {ex.Message}");
                TempData["StatusMessage"] = "Something went wrong.";
                return Page();
            }
        }
    }
}
