using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Microsoft.Extensions.Logging;
using Repo;
using Microsoft.AspNetCore.Http;
using QuachHengToniRazorPages.Helpers;

namespace QuachHengToniRazorPages.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly IRepository<Car> carRepository;
        private readonly IRepository<CarProducer> carProducerRepository;

        [BindProperty]
        public Car Car { get; set; }

        public DetailsModel(ILogger<CreateModel> logger, IRepository<Car> carRepository, IRepository<CarProducer> carProducerRepository)
        {
            this.logger = logger;
            this.carRepository = carRepository;
            this.carProducerRepository = carProducerRepository;
        }

        public IActionResult OnGet(string id)
        {
            if (!SessionHelper.IsSignedIn(HttpContext) || HttpContext.Session.GetString("Role") != "Staff")
            {
                return RedirectToPage("/Auth/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            Car = carRepository.RetrieveById(id);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
