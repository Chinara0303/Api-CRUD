using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Services.DTOs.Country;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _repo;
        public CountryService(IMapper mapper, ICountryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task CreateAsync(CountryCreateDto country)=>await _repo.CreateAsync(_mapper.Map<Country>(country));
       

        public async Task DeleteAsync(int? id)=> await _repo.DeleteAsync(await _repo.GetByIdAsync(id));
        public async Task<IEnumerable<CountryDto>> GetAllAsync() => _mapper.Map<IEnumerable<CountryDto>>(await _repo.GetAllAsync());


        public async Task<CountryDto> GetById(int id) => _mapper.Map<CountryDto>(await _repo.GetByIdAsync(id));

        public async Task SoftDeleteAsync(int? id) => await _repo.SoftDeleteAsync(id);
        
        public async Task UpdateAsync(int? id, CountryUpdateDto country)
        {
            if(id is null) throw new ArgumentNullException("Data is not found");
            var data = await _repo.GetByIdAsync(id);
            if (data is null) throw new NullReferenceException("Data is not found");
            _mapper.Map(country, data);
            await _repo.UpdateAsync(data);
        }
    }
}
