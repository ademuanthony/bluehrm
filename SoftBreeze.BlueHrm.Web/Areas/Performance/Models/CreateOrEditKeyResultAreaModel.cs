using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.Proformances.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Performance.Models
{
    public class CreateOrEditKeyResultAreaModel
    {
        public CreateOrEditKeyResultAreaModel(KeyResultAreaDto input, bool isNew)
        {
            IsEditMode = !isNew;
            Kra = input;
        }

        public bool IsEditMode { get; set; }

        public KeyResultAreaDto Kra { get; set; }
    }
}