using System.Collections.Generic;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Editions.Dto;

namespace SoftBreeze.BlueHrm.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput : IOutputDto
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}