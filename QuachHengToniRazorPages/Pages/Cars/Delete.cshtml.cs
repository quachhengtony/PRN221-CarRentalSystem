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

namespace QuachHengToniRazorPages.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly IRepository<Car> carRepository;
        private readonly IRepository<CarProducer> carProducerRepository;

        [BindProperty]
        public BusinessObject.Car Car { get; set; }

        public DeleteModel(ILogger<CreateModel> logger, IRepository<Car> carRepository, IRepository<CarProducer> carProducerRepository)
        {
            this.logger = logger;
            this.carRepository = carRepository;
            this.carProducerRepository = carProducerRepository;
        }

        public IActionResult OnGet(string id)
        {
            try
            {
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
            catch (Exception ex)
            {
                logger.LogError($"Exception: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                Car = carRepository.RetrieveById(id);

                if (Car != null)
                {
                    carRepository.Delete(Car);
                }

                return RedirectToPage("./Index");
            } catch (Exception ex)
            {
                logger.LogError($"Exception: {ex.Message}");
                return Page();
            }
        }
    }
}
