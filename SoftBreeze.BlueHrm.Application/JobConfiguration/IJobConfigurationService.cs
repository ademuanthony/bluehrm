using System.Collections.Generic;
using System.Security.Policy;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.Authorization.Roles.Dto;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobCategories;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobTerminationReasons;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades;

namespace SoftBreeze.BlueHrm.JobConfiguration
{
    public interface IJobConfigurationService:IApplicationService
    {
        //employment status
        OutputBase CreateOrUpdateEmploymentStatus(CreateOrUpdateEmploymentStatusInput input);
        OutputBase CreateEmploymentStatus(CreateEmploymentStatusInput input);
        OutputBase DeleteEmploymentStatus(DeleteEmploymentStatusInput input);
        ListResultOutput<EmploymentStatusDto> GetEmploymentStatuses();
        EmploymentStatusDto GetEmploymentStatus(GetEmploymentStatusInput input);

        //job
        OutputBase CreateOrUpdateJob(CreateOrUpdateJobInput input);
        OutputBase CreateJob(CreateJobInput input);
        JobDto GetJob(GetJobInput input);
        ListResultOutput<JobDto> GetJobs();
        OutputBase DeleteJob(DeleteJobInput input);

        //Job category
        OutputBase CreateOrUpdateJobCategory(CreateOrUpdateJobCategoryInput input);
        OutputBase CreateJobCategory(CreateJobCategoryInput input);
        OutputBase DeleteJobCategory(DeleteJobCategoryInput input);
        JobCategoryDto GetJobCategory(GetJobCategoryInput input);
        ListResultOutput<JobCategoryDto> GetJobCategories();

        //JobTerminationReason
        OutputBase CreateOrUpdateJobTerminationReason(CreateOrUpdateJobTerminationReasonInput input);
        OutputBase CreateJobTerminationReason(CreateJobTerminationReasonInput input);
        OutputBase DeleteJobTerminationReason(DeleteJobTerminationReasonInput input);
        JobTerminationReasonDto GetJobTerminationReason(GetJobTerminationReasonInput input);
        ListResultOutput<JobTerminationReasonDto> GetJobTerminationReasons();

        //PayGrade
        OutputBase CreateOrUpdatePaygrade(CreateOrUpdatePaygradeInput input);
        OutputBase CreatePayGrade(CreatePayGradeInput input);
        OutputBase DeletePayGrade(DeletePayGradeInput input);
        PayGradeDto GetPayGrade(GetPayGradeInput input);
        ListResultOutput<PayGradeDto> GetPayGrades();
    }
}
