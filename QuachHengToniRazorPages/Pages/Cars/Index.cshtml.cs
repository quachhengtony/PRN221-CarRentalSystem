using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repo;
using Microsoft.Extensions.Logging;

namespace QuachHengToniRazorPages.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IRepository<BusinessObject.Car> carRepository;

        public IndexModel(ILogger<IndexModel> logger, IRepository<BusinessObject.Car> carRepository)
        {
            this.logger = logger;
            this.carRepository = carRepository;
        }

        [BindProperty]
        public IList<BusinessObject.Car> CarList { get; set; }

        public void OnGet()
        {
            CarList = carRepository.Retrieve();
        }
    }
}
