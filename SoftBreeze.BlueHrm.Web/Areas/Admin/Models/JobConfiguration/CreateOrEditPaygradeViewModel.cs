using Castle.Core.Internal;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration
{
    public class CreateOrEditPaygradeViewModel
    {
        public CreateOrEditPaygradeViewModel(PayGradeDto payGrade)
        {
            PayGrade = payGrade;
        }
        public bool IsEditMode { get { return !PayGrade.Name.IsNullOrEmpty(); } }

        public PayGradeDto PayGrade { get; set; }
    }
}