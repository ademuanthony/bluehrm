using Abp.AutoMapper;
using SoftBreeze.BlueHrm.Editions.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Common;

namespace SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Editions
{
    [AutoMapFrom(typeof(GetEditionForEditOutput))]
    public class CreateOrEditEditionModalViewModel : GetEditionForEditOutput, IFeatureEditViewModel
    {
        public bool IsEditMode
        {
            get { return Edition.Id.HasValue; }
        }

        public CreateOrEditEditionModalViewModel(GetEditionForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}