using SoftBreeze.BlueHrm.Proformances.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Performance.Models
{
    public class CreateOrEditKeyResultAreaAttributeModel
    {
        public CreateOrEditKeyResultAreaAttributeModel(PerformacneIndicatorDto input, bool isNew)
        {
            IsEditMode = !isNew;
            Attribute = input;
        }

        public bool IsEditMode { get; set; }

        public PerformacneIndicatorDto Attribute { get; set; }
    }
}