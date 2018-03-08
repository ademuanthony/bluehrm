using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration.Payrol;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public interface IConfigurationService:IApplicationService
    {
        //country
        CountryDto GetCountry(GetCountryInput input);
        ListResultOutput<CountryDto> GetCountries();

        //currency
        ListResultOutput<CurrencyDto> GetCurrencies();
        CurrencyDto GetCurrency(GetCurrencyInput input);

        //pay frequency
        ListResultOutput<SalaryPayFrequencyDto> GetPayFrequencies();
        SalaryPayFrequencyDto GetPayFrequency(GetSalaryPayFrequencyInput input);

        //salary compunent
        ListResultOutput<SalaryCompunentDto> GetSalaryCompunents();
        SalaryCompunentDto GetSalaryCompunent(GetSalaryCompunentInput input);
    }
    public class ConfigurationService:BlueHrmAppServiceBase,IConfigurationService
    {
        private readonly ICountyRepository _countryRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ISalaryPayFrequencyRespository _payFrequencyRespository;
        private readonly ISalaryComponentRepository _salaryComponentRepository;

        public ConfigurationService(ICountyRepository countyRepository,
            ICurrencyRepository currencyRepository,
            ISalaryPayFrequencyRespository payFrequencyRespository,
            ISalaryComponentRepository salaryComponentRepository)
        {
            _countryRepository = countyRepository;
            _currencyRepository = currencyRepository;
            _payFrequencyRespository = payFrequencyRespository;
            _salaryComponentRepository = salaryComponentRepository;
        }

        public CountryDto GetCountry(GetCountryInput input)
        {
            return Mapper.Map<CountryDto>(_countryRepository.FirstOrDefault(c => c.Id == input.CountryId));
        }

        public ListResultOutput<CountryDto> GetCountries()
        {
            return new ListResultOutput<CountryDto>(Mapper.Map<List<CountryDto>>(_countryRepository.GetAll()));
        }

        //currencies
        public ListResultOutput<CurrencyDto> GetCurrencies()
        {
            return new ListResultOutput<CurrencyDto>(Mapper.Map<List<CurrencyDto>>(_currencyRepository.GetAll()));
        }

        public CurrencyDto GetCurrency(GetCurrencyInput input)
        {
            return Mapper.Map<CurrencyDto>(_currencyRepository.Get(input.CurrencyId));
        }

        //pay frequency
        public ListResultOutput<SalaryPayFrequencyDto> GetPayFrequencies()
        {
            return new ListResultOutput<SalaryPayFrequencyDto>(Mapper.Map<List<SalaryPayFrequencyDto>>(_payFrequencyRespository.GetAll()));
        }

        public SalaryPayFrequencyDto GetPayFrequency(GetSalaryPayFrequencyInput input)
        {
            return Mapper.Map<SalaryPayFrequencyDto>(_payFrequencyRespository.Get(input.SalaryPayFrequencyId));
        }

        //salary compunent
        public ListResultOutput<SalaryCompunentDto> GetSalaryCompunents()
        {
            return new ListResultOutput<SalaryCompunentDto>(Mapper.Map<List<SalaryCompunentDto>>(_salaryComponentRepository.GetAll()));
        }

        public SalaryCompunentDto GetSalaryCompunent(GetSalaryCompunentInput input)
        {
            return Mapper.Map<SalaryCompunentDto>(_salaryComponentRepository.Get(input.SalaryCompunentId));
        }
    }
}
