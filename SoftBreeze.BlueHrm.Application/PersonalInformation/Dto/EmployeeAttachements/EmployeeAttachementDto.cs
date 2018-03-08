using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeAttachements
{
   public class EmployeeAttachementDto:AttachementDto
    {
        public int EmployeeId { get; set; }
        /// <summary>
        /// this holds the type of attachment which is 
        /// a full qualified type of the class
        /// </summary>
        public string Type { get; set; }
    }
}
