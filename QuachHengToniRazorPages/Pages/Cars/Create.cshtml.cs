using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using QuachHengToniRazorPages.DTO;
using QuachHengToniRazorPages.Helpers;
using QuachHengToniRazorPages.Pages.User;
using Repo;
//using BusinessObject;

namespace QuachHengToniRazorPages.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly IRepository<Car> carRepository;
        private readonly IRepository<CarProducer> carProducerRepository;

        [BindProperty]
        public CreateCarDTO CreateCarDTO { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IRepository<Car> carRepository, IRepository<CarProducer> carProducerRepository)
        {
            this.logger = logger;
            this.carRepository = carRepository;
            this.carProducerRepository = carProducerRepository;
        }

        public IActionResult OnGet()
        {
            if (!SessionHelper.IsSignedIn(HttpContext) || HttpContext.Session.GetString("Role") != "Staff")
            {
                return RedirectToPage("/Auth/Login");
            }

            ViewData["Producers"] = new SelectList(carProducerRepository.Retrieve(), "ProducerId", "ProcuderName");
            return Page();
        }

        //[BindProperty]
        //public BusinessObject.Car { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var car = new Car()
                {
                    CarId = CreateCarDTO.CarId,
                    Capacity = CreateCarDTO.Capacity,
                    CarModelYear = CreateCarDTO.CarModelYear,
                    CarName = CreateCarDTO.CarName,
                    Color = CreateCarDTO.Color,
                    Description = CreateCarDTO.Description,
                    ImportDate = CreateCarDTO.ImportDate,
                    ProducerId = CreateCarDTO.ProducerId,
                    RentPrice = CreateCarDTO.RentPrice,
                    Status = CreateCarDTO.Status,
                };
                carRepository.Create(car);

                return RedirectToPage("Index");
            }
            catch (Exception ex) 
            {
                logger.LogError($"Exception: {ex.Message}");
                return Page();
            }
        }
    }
}
