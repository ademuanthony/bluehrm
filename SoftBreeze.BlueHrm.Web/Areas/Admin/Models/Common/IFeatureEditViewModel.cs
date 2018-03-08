using System.Collections.Generic;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Editions.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}