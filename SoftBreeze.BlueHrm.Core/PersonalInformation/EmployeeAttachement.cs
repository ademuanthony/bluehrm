using System.ComponentModel.DataAnnotations.Schema;
using BlueHrm;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class EmployeeAttachement:Attachement
    {
        public long EmployeeId { get; set; }
        /// <summary>
        /// this holds the type of attachment which is 
        /// a full qualified type of the class
        /// </summary>
        public string Type { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
