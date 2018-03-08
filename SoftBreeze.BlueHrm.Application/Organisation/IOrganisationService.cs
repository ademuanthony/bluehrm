using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.Organisation.Dto;
using SoftBreeze.BlueHrm.Organisation.Dto.Locations;
using SoftBreeze.BlueHrm.Organisation.Dto.Units;

namespace SoftBreeze.BlueHrm.Organisation
{
    public interface IOrganisationService:IApplicationService
    {
        //GeneralInformation
        GeneralInformationDto GetGeneralInformation();
        OutputBase SaveGernalInformation(SaveGerneralInformationInput input);

        //location
        OutputBase CreateOrUpdateLocation(CreateOrUpdateLocationInput input);
        OutputBase CreateLocation(CreateLocationInput input);
        OutputBase UpdateLocation(UpdateLocationInput input);
        OutputBase DeleteLocation(DeleteLocationInput input);
        LocationDto GetLocation(GetLocationInput input);
        ListResultOutput<LocationDto> GetLocations();

        //units
        OutputBase CreateOrUpdateUnit(CreateOrUpdateUnitInput input);
        OutputBase CreateUnit(CreateUnitInput input);
        OutputBase UpdateUnit(UpdateUnitInput input);
        UnitDto GetUnit(GetUnitInput input);
        ListResultOutput<UnitDto> GetUnits();
    }
}
