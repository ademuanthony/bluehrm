using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using AutoMapper;
using Castle.Windsor.Installer;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.Organisation;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration;
using SoftBreeze.BlueHrm.Organisation.Dto;
using SoftBreeze.BlueHrm.Organisation.Dto.Locations;
using SoftBreeze.BlueHrm.Organisation.Dto.Units;
using SoftBreeze.BlueHrm.Organization;

namespace SoftBreeze.BlueHrm.Organisation
{
    public class OrganisationService:BlueHrmAppServiceBase, IOrganisationService
    {
        private readonly IGeneralInformationRepository _generalInformationRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitRepository _unitRepository;

        public OrganisationService(IGeneralInformationRepository generalInformationRepository,
            ILocationRepository locationRepository,
            IUnitRepository unitRepository)
        {
            _generalInformationRepository = generalInformationRepository;
            _locationRepository = locationRepository;
            _unitRepository = unitRepository;
        }

        #region GeneralInformation
        public GeneralInformationDto GetGeneralInformation()
        {
            return Mapper.Map<GeneralInformationDto>(_generalInformationRepository.GetAll().FirstOrDefault());
        }

        public OutputBase SaveGernalInformation(SaveGerneralInformationInput input)
        {
            _generalInformationRepository.InsertOrUpdate(Mapper.Map<GeneralInformation>(input));
            return new OutputBase {Message = "Changes saved", Success = true};
        }

        #endregion

        #region Location

        public OutputBase CreateOrUpdateLocation(CreateOrUpdateLocationInput input)
        {
            try
            {
                if (_locationRepository.Query(q => q.Any(l => l.Name == input.Location.Name && l.Id != input.Location.Id)))
                {
                    return new OutputBase {Message = "A location with the same name already added", Success = false};
                }
                var location = Mapper.Map<Location>(input.Location);
                var id  = _locationRepository.InsertOrUpdateAndGetId(location);
                return new OutputBase {Message = "Location saved", Success = true, Id = id};
            }
            catch (Exception exception)
            {
                return new OutputBase {Message = exception.Message, Success = false};
            }
        }

        public OutputBase CreateLocation(CreateLocationInput input)
        {
            _locationRepository.Insert(Mapper.Map<Location>(input));
            return new OutputBase {Message = "Location Added", Success = true};
        }

        public OutputBase UpdateLocation(UpdateLocationInput input)
        {
            _locationRepository.Update(Mapper.Map<Location>(input));
            return new OutputBase {Message = "Location updated", Success = true};
        }
        public OutputBase DeleteLocation(DeleteLocationInput input)
        {
            _locationRepository.Delete(input.LocationId);
            return new OutputBase {Message = "Location deleted"};
        }

        public LocationDto GetLocation(GetLocationInput input)
        {
            return Mapper.Map<LocationDto>(_locationRepository.Get(input.LocationId));
        }

        public ListResultOutput<LocationDto> GetLocations()
        {
            return new ListResultOutput<LocationDto>(Mapper.Map<List<LocationDto>>(_locationRepository.GetAll()));
        }


        #endregion

        #region units

        public OutputBase CreateOrUpdateUnit(CreateOrUpdateUnitInput input)
        {
            if (_unitRepository.Query(q => q.Any(u => u.Name == input.Unit.Name && u.Id != input.Unit.Id)))
            {
                return new OutputBase {Message = "A unit with the same name already exist", Success = false};
            }
            _unitRepository.InsertOrUpdate(Mapper.Map<Unit>(input.Unit));
            return new OutputBase {Message = "Unit saved", Success = true};
        }

        public OutputBase CreateUnit(CreateUnitInput input)
        {
            if (_unitRepository.Query(q => q.Any(u => u.Name == input.Name)))
            {
                return new OutputBase {Message = "A unit with the same name already exist", Success = false};
            }
            _unitRepository.Insert(Mapper.Map<Unit>(input));
            return new OutputBase {Message = "Unit added", Success = true};
        }

        public OutputBase UpdateUnit(UpdateUnitInput input)
        {
            if (_unitRepository.Query(q => q.Any(u => u.Name == input.Name && u.Id != input.Id)))
            {
                return new OutputBase {Message = "A unit with the same name already exists", Success = false};
            }
            _unitRepository.Update(Mapper.Map<Unit>(input));
            return new OutputBase {Message = "Unit updated", Success = true};
        }

        public UnitDto GetUnit(GetUnitInput input)
        {
            return Mapper.Map<UnitDto>(_unitRepository.Get(input.UnitId));
        }

        public ListResultOutput<UnitDto> GetUnits()
        {
            return new ListResultOutput<UnitDto>(Mapper.Map<List<UnitDto>>(_unitRepository.GetAll()));
        }
        #endregion
    }
}
