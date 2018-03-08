using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public interface IQualificationService : IApplicationService
    {
        OutputBase CreateOrEditSkill(CreateOrEditSkillInput input);
        SkillDto GetSkill(GetSkillInput input);
        ListResultOutput<SkillDto> GetSkills();
        OutputBase DeleteSkill(DeleteSkillInput input);


        OutputBase CreateOrEditEducationLevel(CreateOrEditEducationLevelInput input);
        EducationLevelDto GetEducationLevel(GetEducationLevelInput input);
        ListResultOutput<EducationLevelDto> GetEducationLevels();
        OutputBase DeleteEducationLevel(DeleteEducationLevelInput input);

        OutputBase CreateOrEditLicenseType(CreateOrEditLicenseTypeInput input);
        LicenseTypeDto GetLicenseType(GetLicenseTypeInput input);
        ListResultOutput<LicenseTypeDto> GetLicenseTypes();
        OutputBase DeleteLicenseType(DeleteLicenseTypeInput input);

    }

    public class QualificationService:BlueHrmAppServiceBase, IQualificationService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IEducationalLevelRepository _educationalLevelRepository;
        private readonly ILicenseTypeRepository _licenseTypeRepository;

        public QualificationService(ISkillRepository skillRepository,
            IEducationalLevelRepository educationalLevelRepository,
            ILicenseTypeRepository licenseTypeRepository
            )
        {
            _skillRepository = skillRepository;
            _educationalLevelRepository = educationalLevelRepository;
            _licenseTypeRepository = licenseTypeRepository;
        }

        #region skills
        public OutputBase CreateOrEditSkill(CreateOrEditSkillInput input)
        {
            if (_skillRepository.Query(q => q.Any(s => s.Name == input.Skill.Name && s.Id != input.Skill.Id)))
            {
                return new OutputBase {Message = "A skill with the same name have been added", Success = true};
            }
            _skillRepository.InsertOrUpdate(Mapper.Map<Skill>(input.Skill));
            return new OutputBase {Message = "Skill added", Success = true};
        }

        public SkillDto GetSkill(GetSkillInput input)
        {
            return Mapper.Map<SkillDto>(_skillRepository.Get(input.SkillId));
        }

        public ListResultOutput<SkillDto> GetSkills()
        {
            return new ListResultOutput<SkillDto>(Mapper.Map<List<SkillDto>>(_skillRepository.GetAll()));
        }

        public OutputBase DeleteSkill(DeleteSkillInput input)
        {
            _skillRepository.Delete(input.SkillId);
            return new OutputBase {Message = "Skill Deleted", Success = true};
        }

        #endregion

        #region education

        public OutputBase CreateOrEditEducationLevel(CreateOrEditEducationLevelInput input)
        {
            if (input.EducationLevel.Name.IsNullOrEmpty())
                return new OutputBase {Message = "Please enter a name for this level", Success = false};
            if (_educationalLevelRepository.Query(q => q.Any(ed => ed.Name == input.EducationLevel.Name)))
            {
                return new OutputBase {Message = "A level with the same name have alreay been added", Success = false};
            }

            _educationalLevelRepository.InsertOrUpdate(Mapper.Map<EducationalLevel>(input.EducationLevel));
            return new OutputBase {Message = "Level added", Success = true};
        }

        public EducationLevelDto GetEducationLevel(GetEducationLevelInput input)
        {
            return Mapper.Map<EducationLevelDto>(_educationalLevelRepository.Get(input.EducationLevelId));
        }

        public ListResultOutput<EducationLevelDto> GetEducationLevels()
        {
            return new ListResultOutput<EducationLevelDto>(Mapper.Map<List<EducationLevelDto>>(_educationalLevelRepository.GetAll()));
        }

        public OutputBase DeleteEducationLevel(DeleteEducationLevelInput input)
        {
            _educationalLevelRepository.Delete(input.EducationLevelId);
            return new OutputBase {Message = "Level deleted", Success = true};
        }

        #endregion

        #region LicenseType

        public OutputBase CreateOrEditLicenseType(CreateOrEditLicenseTypeInput input)
        {
            if (input.LicenseType.Name.IsNullOrEmpty())
                return new OutputBase {Message = "Name cannot be empty", Success = false};
            if (
                _licenseTypeRepository.Query(
                    q => q.Any(lic => lic.Name == input.LicenseType.Name && lic.Id != input.LicenseType.Id)))
            {
                return new OutputBase {Message = "A License with the same name already added", Success = false};
            }
            _licenseTypeRepository.InsertOrUpdate(Mapper.Map<LicenseType>(input.LicenseType));
            return new OutputBase {Message = "License type added", Success = true};
        }

        public LicenseTypeDto GetLicenseType(GetLicenseTypeInput input)
        {
            return Mapper.Map<LicenseTypeDto>(_licenseTypeRepository.Get(input.LicenseTypeId));
        }

        public ListResultOutput<LicenseTypeDto> GetLicenseTypes()
        {
            return
                new ListResultOutput<LicenseTypeDto>(Mapper.Map<List<LicenseTypeDto>>(_licenseTypeRepository.GetAll()));
        }

        public OutputBase DeleteLicenseType(DeleteLicenseTypeInput input)
        {
            _licenseTypeRepository.Delete(input.LicenseTypeId);
            return new OutputBase {Message = "License type deleted", Success = true};
        }
        #endregion
    }
}
