using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Microsoft.Extensions.Logging;
using Repo;
using QuachHengToniRazorPages.DTO;

namespace QuachHengToniRazorPages.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> logger;
        private readonly IRepository<BusinessObject.Car> carRepository;
        private readonly IRepository<BusinessObject.CarProducer> carProducerRepository;
        private string CarId { get; set; }

        public EditModel(ILogger<EditModel> logger, IRepository<BusinessObject.Car> carRepository, IRepository<BusinessObject.CarProducer> carProducerRepository)
        {
            this.logger = logger;
            this.carRepository = carRepository;
            this.carProducerRepository = carProducerRepository;
        }

        [BindProperty]
        public Car Car { get; set; }

        [BindProperty]
        public UpdateCarDTO WriteCarDTO { get; set; }

        public IActionResult OnGet(string id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                CarId = id;
                Car = carRepository.RetrieveById(CarId);

                if (Car == null)
                {
                    return NotFound();
                }

                ViewData["Producers"] = new SelectList(carProducerRepository.Retrieve(), "ProducerId", "ProcuderName");
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = "Something went wrong.";
                logger.LogError($"Exception: {ex.Message}");
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(string id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["StatusMessage"] = "Invalid data.";
                    return Page();
                }

                Car = carRepository.RetrieveById(Car.CarId);

                if (Car == null)
                {
                    return NotFound();
                }

                Car.CarName = WriteCarDTO.CarName ?? Car.CarName;
                Car.Capacity = WriteCarDTO.Capacity ?? Car.Capacity;
                Car.CarModelYear = WriteCarDTO.CarModelYear ?? Car.CarModelYear;
                Car.Color = WriteCarDTO.Color ?? Car.Color;
                Car.Description = WriteCarDTO.Description ?? Car.Description;
                Car.ImportDate = WriteCarDTO.ImportDate ?? Car.ImportDate;
                Car.ProducerId = WriteCarDTO.ProducerId ?? Car.ProducerId;
                Car.RentPrice = WriteCarDTO.RentPrice ?? Car.RentPrice;
                Car.Status = WriteCarDTO.Status ?? Car.Status;

                carRepository.Update(Car);

                return RedirectToPage("./Index");
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
