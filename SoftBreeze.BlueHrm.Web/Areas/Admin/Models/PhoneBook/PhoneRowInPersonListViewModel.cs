using Abp.Localization;
using SoftBreeze.BlueHrm.People.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.PhoneBook
{
    public class PhoneRowInPersonListViewModel
    {
        public PhoneInPersonListDto Phone { get; set; }

        public PhoneRowInPersonListViewModel(PhoneInPersonListDto phone)
        {
            Phone = phone;
        }

        public string GetPhoneTypeAsString()
        {
            return LocalizationHelper.GetString(BlueHrmConsts.LocalizationSourceName, "PhoneType_" + Phone.Type);
        }
    }
}