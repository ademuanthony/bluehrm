﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Editions.Dto;

namespace SoftBreeze.BlueHrm.Editions
{
    public interface IEditionAppService : IApplicationService
    {
        Task<ListResultOutput<EditionListDto>> GetEditions();

        Task<GetEditionForEditOutput> GetEditionForEdit(NullableIdInput input);

        Task CreateOrUpdateEdition(CreateOrUpdateEditionDto input);

        Task DeleteEdition(EntityRequestInput input);
    }
}