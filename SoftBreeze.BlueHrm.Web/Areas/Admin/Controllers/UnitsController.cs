using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Collections.Extensions;
using SoftBreeze.BlueHrm.Organisation;
using SoftBreeze.BlueHrm.Organisation.Dto.Locations;
using SoftBreeze.BlueHrm.Organisation.Dto.Units;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Organisation;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class UnitsController : Controller
    {
        private readonly IOrganisationService _service;

        public UnitsController(IOrganisationService service)
        {
            _service = service;
        }

        // GET: Admin/JobTitles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new UnitDto();
            if (id != null)
            {
                output = _service.GetUnit(new GetUnitInput {UnitId = id.Value});
            }
            var viewModel = new CreateOrEditUnitViewModel(output);

            var parent = id == null?_service.GetUnits().Items: 
                _service.GetUnits().Items.Where(u => u.Id != id.Value && (u.ParentId == null || u.ParentId != id));
            ViewBag.ParentId = new SelectList(parent, "Id", "Name");

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}