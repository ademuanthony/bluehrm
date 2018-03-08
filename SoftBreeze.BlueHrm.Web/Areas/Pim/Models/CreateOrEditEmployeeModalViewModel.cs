using SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditEmployeeModalViewModel
    {
        public CreateOrEditEmployeeModalViewModel(EmployeeDto employee)
        {
            Employee = employee;
        }
        public EmployeeDto Employee { get; set; }
        public string Paswword { get; set; }
        public bool IsEditMode { get { return Employee.Id > 0; } }
        
    }
}