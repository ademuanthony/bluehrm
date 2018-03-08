using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.Organisation;
using SoftBreeze.BlueHrm.Organisation.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class GeneralInformationController : Controller
    {
        private readonly IOrganisationService _organisationService;

        public GeneralInformationController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }
        // GET: Admin/GeneralInformation
        public ActionResult Index()
        {
            var model = _organisationService.GetGeneralInformation();
            return View(model??new GeneralInformationDto());
        }
    }
}