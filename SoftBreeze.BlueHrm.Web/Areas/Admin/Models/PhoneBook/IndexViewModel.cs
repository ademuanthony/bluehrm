using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Localization;
using SoftBreeze.BlueHrm.People;
using SoftBreeze.BlueHrm.People.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.PhoneBook
{
    [AutoMapFrom(typeof(ListResultOutput<PersonListDto>))]
    public class IndexViewModel : ListResultOutput<PersonListDto>
    {
        public string Filter { get; set; }

        public IndexViewModel(ListResultOutput<PersonListDto> output, string filter = null)
        {
            output.MapTo(this);
            Filter = filter;
        }

        public string GetPhoneTypeAsString(PhoneType type)
        {
            return LocalizationHelper.GetString(BlueHrmConsts.LocalizationSourceName, "PhoneType_" + type);
        }
    }
}