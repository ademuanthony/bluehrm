using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.Common;
using SoftBreeze.BlueHrm.MultiTenancy;
using SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Tenants;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenants)]
    public class TenantsController : BlueHrmControllerBase
    {
        private readonly ITenantAppService _tenantAppService;
        private readonly ICommonLookupAppService _lookupAppService;
        private readonly TenantManager _tenantManager;

        public TenantsController(
            ITenantAppService tenantAppService,
            ICommonLookupAppService lookupAppService, 
            TenantManager tenantManager)
        {
            _tenantAppService = tenantAppService;
            _lookupAppService = lookupAppService;
            _tenantManager = tenantManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> CreateModal()
        {
            var editionItems = await GetEditionComboboxItems();
            var viewModel = new CreateTenantViewModel(editionItems);

            return PartialView("_CreateModal", viewModel);
        }
        
        public async Task<PartialViewResult> EditModal(int id)
        {
            var tenantEditDto = await _tenantAppService.GetTenantForEdit(new EntityRequestInput(id));
            var editionItems = await GetEditionComboboxItems(tenantEditDto.EditionId);
            var viewModel = new EditTenantViewModel(tenantEditDto, editionItems);

            return PartialView("_EditModal", viewModel);
        }

        public async Task<PartialViewResult> FeaturesModal(int id)
        {
            var tenant = await _tenantManager.GetByIdAsync(id);
            var output = await _tenantAppService.GetTenantFeaturesForEdit(new EntityRequestInput(id));
            var viewModel = new TenantFeaturesEditViewModel(tenant, output);

            return PartialView("_FeaturesModal", viewModel);
        }

        private async Task<List<ComboboxItemDto>> GetEditionComboboxItems(int? selectedEditionId = null)
        {
            var editionItems = (await _lookupAppService.GetEditionsForCombobox()).Items.ToList();

            var defaultItem = new ComboboxItemDto("null", L("NotAssigned"));
            editionItems.Insert(0, defaultItem);
            
            if (selectedEditionId.HasValue)
            {
                var selectedEdition = editionItems.FirstOrDefault(e => e.Value == selectedEditionId.Value.ToString());
                if (selectedEdition != null)
                {
                    selectedEdition.IsSelected = true;
                }
            }
            else
            {
                defaultItem.IsSelected = true;
            }

            return editionItems;
        }
    }
}