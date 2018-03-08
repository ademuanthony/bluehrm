using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.Organisation.Dto.Units;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Organisation
{
    public class CreateOrEditUnitViewModel
    {
        public CreateOrEditUnitViewModel(UnitDto unit)
        {
            Unit = unit;
        }

        public UnitDto Unit { get; set; }

        public bool IsEditMode { get { return !Unit.Name.IsNullOrEmpty(); } }
    }
}