using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Contacts
{
    public class SaveContactInput:IInputDto
    {
        public ContactDto Contact { get; set; }
    }
}
