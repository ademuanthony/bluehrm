using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.Organisation.Dto.Locations;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Organisation
{
    public class CreateOrEditLoationViewModel
    {
        public CreateOrEditLoationViewModel(LocationDto location)
        {
            Location = location;
        }

        public LocationDto Location { get; set; }

        public bool IsEditMode { get { return !Location.Name.IsNullOrEmpty(); } }
    }
}