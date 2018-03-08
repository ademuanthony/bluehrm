using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using AutoMapper;
using BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobCategories;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobTerminationReasons;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades;

namespace SoftBreeze.BlueHrm.JobConfiguration
{
    public class JobConfigurationService: IJobConfigurationService
    {
        private readonly IEmploymentStatusRepository _employmentStatusRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IJobCategoryRepository _jobCategoryRepository;
        private readonly IJobTerminationReasonRepository _jobTerminationReasonRepository;
        private readonly IPayGradeRepository _payGradeRepository;

        public JobConfigurationService(
            IEmploymentStatusRepository employmentStatusRepository,
            IJobRepository jobRepository,
            IJobCategoryRepository jobCategoryRepository,
            IJobTerminationReasonRepository jobTerminationReasonRepository,
            IPayGradeRepository payGradeRepository)
        {
            _employmentStatusRepository = employmentStatusRepository;
            _jobRepository = jobRepository;
            _jobCategoryRepository = jobCategoryRepository;
            _jobTerminationReasonRepository = jobTerminationReasonRepository;
            _payGradeRepository = payGradeRepository;
        }

        #region employment status

        public OutputBase CreateOrUpdateEmploymentStatus(CreateOrUpdateEmploymentStatusInput input)
        {
            if (_employmentStatusRepository.Query(q => q.Any(emp => emp.Name == input.EmploymentStatus.Name)))
            {
                return new OutputBase {Message = "A status with the same name has already been added", Success = true};
            }
            if (input.EmploymentStatus.Id == 0)
            {
                _employmentStatusRepository.Insert(Mapper.Map<EmploymentStatus>(input.EmploymentStatus));
            }
            else _employmentStatusRepository.Update(Mapper.Map<EmploymentStatus>(input.EmploymentStatus));
            return new OutputBase {Message = "Status saved", Success = true};
        }

        public OutputBase CreateEmploymentStatus(CreateEmploymentStatusInput input)
        {
            if (_employmentStatusRepository.Query(q => q.Any(e => e.Name == input.Name)))
            {
                return new OutputBase {Message = "A status with the same name already exist", Success = false};
            }
            _employmentStatusRepository.Insert(Mapper.Map<EmploymentStatus>(input));
            return new OutputBase {Message = "Statud added", Success = true};
        }

        public OutputBase DeleteEmploymentStatus(DeleteEmploymentStatusInput input)
        {
            _employmentStatusRepository.Delete(input.Id);
            return new OutputBase {Message = "Status deleted", Success = true};
        }


        public ListResultOutput<EmploymentStatusDto> GetEmploymentStatuses()
        {
            return new ListResultOutput<EmploymentStatusDto>(Mapper.Map<List<EmploymentStatusDto>>(_employmentStatusRepository.GetAll()));
        }

        public EmploymentStatusDto GetEmploymentStatus(GetEmploymentStatusInput input)
        {
            return Mapper.Map<EmploymentStatusDto>(_employmentStatusRepository.Get(input.Id));
        }

        #endregion

        #region job

        public OutputBase CreateOrUpdateJob(CreateOrUpdateJobInput input)
        {
            if (input.Job.Id == 0)
            {
                return CreateJob(Mapper.Map<CreateJobInput>(input.Job));
            }
            if (_jobRepository.Query(q => q.Any(j => j.Title == input.Job.Title && j.Id != input.Job.Id)))
            {
                return new OutputBase {Message = "A job with thesame title already added", Success = false};
            }
            _jobRepository.Update(Mapper.Map<Job>(input.Job));
            return new OutputBase {Message = "Save scucceded", Success = true};
        }

        public OutputBase CreateJob(CreateJobInput input)
        {
            if (_jobRepository.Query(q => q.Any(j => j.Title == input.Title)))
            {
                return new OutputBase {Message = "A job with the same title already exists", Success = false};
            }
            var id = _jobRepository.InsertAndGetId(Mapper.Map<Job>(input));
            return new OutputBase {Message = "Job added", Success = true};
        }

        public JobDto GetJob(GetJobInput input)
        {
            return Mapper.Map<JobDto>(_jobRepository.Get(input.JobId));
        }

        public ListResultOutput<JobDto> GetJobs()
        {
            return new ListResultOutput<JobDto>(Mapper.Map<List<JobDto>>(_jobRepository.GetAll()));
        }

        public OutputBase DeleteJob(DeleteJobInput input)
        {
            _jobRepository.Delete(input.JobId);
            return new OutputBase {Message = "job deleted", Success = true};
        }

        #endregion

        #region job category
        public OutputBase CreateOrUpdateJobCategory(CreateOrUpdateJobCategoryInput input)
        {
            if (
                _jobCategoryRepository.Query(
                    q => q.Any(jc => jc.Name == input.JobCategory.Name && jc.Id != input.JobCategory.Id)))
            {
                return new OutputBase {Message = "A category with the same already added", Success = false};
            }
            if (input.JobCategory.Id == 0)
                _jobCategoryRepository.Insert(Mapper.Map<JobCategory>(input.JobCategory));
            else
            {
                _jobCategoryRepository.Update(Mapper.Map<JobCategory>(input.JobCategory));
            }
            return new OutputBase {Message = "Category saved", Success = true};
        }
        public OutputBase CreateJobCategory(CreateJobCategoryInput input)
        {
            if (_jobCategoryRepository.Query(q => q.Any(jc => jc.Name == input.Name)))
            {
                return new OutputBase {Message = "A Category with the same name already exists", Success = false};
            }
            _jobCategoryRepository.Insert(Mapper.Map<JobCategory>(input));
            return new OutputBase {Message = "Category Added", Success = true};

        }

        public OutputBase DeleteJobCategory(DeleteJobCategoryInput input)
        {
            _jobCategoryRepository.Delete(input.CategoryId);
            return new OutputBase {Message = "Category deleted", Success = true};
        }

        public JobCategoryDto GetJobCategory(GetJobCategoryInput input)
        {
            return Mapper.Map<JobCategoryDto>(_jobCategoryRepository.Get(input.CategoryId));
        }
         
        public ListResultOutput<JobCategoryDto> GetJobCategories()
        {
            return new ListResultOutput<JobCategoryDto>(Mapper.Map<List<JobCategoryDto>>(_jobCategoryRepository.GetAll()));
        }
        #endregion

        #region JobTerminationReason

        public OutputBase CreateOrUpdateJobTerminationReason(CreateOrUpdateJobTerminationReasonInput input)
        {
            if (_jobTerminationReasonRepository.Query(q => q.Any(t => t.Name == input.JobTerminationReason.Name)))
            {
                return new OutputBase {Message = "A reason with the same naem has already been added", Success = false};
            }
            if (input.JobTerminationReason.Id == 0)
                _jobTerminationReasonRepository.Insert(Mapper.Map<JobTerminationReason>(input.JobTerminationReason));
            else _jobTerminationReasonRepository.Update(Mapper.Map<JobTerminationReason>(input.JobTerminationReason));
            return new OutputBase {Message = "Record saved", Success = true};
        }
        public OutputBase CreateJobTerminationReason(CreateJobTerminationReasonInput input)
        {
            if (_jobTerminationReasonRepository.Query(q => q.Any(jt => jt.Name == input.Name)))
            {
                return new OutputBase {Message = "A reason with the same name already exists", Success = false};
            }
            _jobTerminationReasonRepository.Insert(Mapper.Map<JobTerminationReason>(input));
            return new OutputBase {Message = "Reason added", Success = true};
        }

        public OutputBase DeleteJobTerminationReason(DeleteJobTerminationReasonInput input)
        {
            _jobTerminationReasonRepository.Delete(input.JobTerminationReasonId);
            return new OutputBase {Message = "Reason deleted", Success = true};
        }

        public JobTerminationReasonDto GetJobTerminationReason(GetJobTerminationReasonInput input)
        {
            return Mapper.Map<JobTerminationReasonDto>(_jobTerminationReasonRepository.Get(input.JobTerminationReasonId));
        }

        public ListResultOutput<JobTerminationReasonDto> GetJobTerminationReasons()
        {
            return new ListResultOutput<JobTerminationReasonDto>(Mapper.Map<List<JobTerminationReasonDto>>(_jobTerminationReasonRepository.GetAll()));
        }
        #endregion

        #region PayGrade

        public OutputBase CreateOrUpdatePaygrade(CreateOrUpdatePaygradeInput input)
        {
            if (
                     _payGradeRepository.Query(
                         q => q.Any(p => p.Name == input.PayGrade.Name && p.Id != input.PayGrade.Id)))
            {
                return new OutputBase
                {
                    Message = "A record with the same name has already been added",
                    Success = false
                };
            }

            if (input.PayGrade.Id == 0)
                _payGradeRepository.Insert(Mapper.Map<PayGrade>(input.PayGrade));
            else
                _payGradeRepository.Update(Mapper.Map<PayGrade>(input.PayGrade));
            return new OutputBase {Message = "Record added", Success = true};
        }
        
        public OutputBase CreatePayGrade(CreatePayGradeInput input)
        {
            if (_payGradeRepository.Query(q => q.Any(pg => pg.Name == input.Name)))
            {
                return new OutputBase {Message = "A pay grade with the same name already existed", Success = false};
            }
            _payGradeRepository.Insert(Mapper.Map<PayGrade>(input));
            return new OutputBase {Message = "Pay grade added", Success = false};
        }

        public OutputBase DeletePayGrade(DeletePayGradeInput input)
        {
            _payGradeRepository.Delete(input.PayGradeId);
            return new OutputBase {Message = "Pay grade deleted", Success = true};
        }

        public PayGradeDto GetPayGrade(GetPayGradeInput input)
        {
            return Mapper.Map<PayGradeDto>(_payGradeRepository.Get(input.PayGradeId));
        }

        public ListResultOutput<PayGradeDto> GetPayGrades()
        {
            return new ListResultOutput<PayGradeDto>(Mapper.Map<List<PayGradeDto>>(_payGradeRepository.GetAll()));
        }
        #endregion
    }
}
