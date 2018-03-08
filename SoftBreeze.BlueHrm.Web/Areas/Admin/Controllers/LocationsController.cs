using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.Organisation;
using SoftBreeze.BlueHrm.Organisation.Dto.Locations;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Organisation;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IOrganisationService _service;
        private readonly IConfigurationService _configurationService;

        public LocationsController(IOrganisationService service, IConfigurationService configurationService)
        {
            _service = service;
            _configurationService = configurationService;
        }

        // GET: Admin/JobTitles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new LocationDto();
            if (id != null)
            {
                output = _service.GetLocation(new GetLocationInput {LocationId = id.Value});
            }
            var viewModel = new CreateOrEditLoationViewModel(output);

            ViewBag.CountryId = new SelectList(_configurationService.GetCountries().Items, "Id", "Name", output.CountryId);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}