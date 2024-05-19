using AliExpress.Application.Contract;
using AliExpress.Application.IServices;
using AliExpress.Dtos.Product;
using AliExpress.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Services
{
    public class PrdouctBrandService: IPrdouctBrandService
    {
        private readonly IPrdouctBrandRepository _prdouctBrandRepository;
        private readonly IMapper _mapper;

        public PrdouctBrandService(IPrdouctBrandRepository prdouctBrandRepository, IMapper mapper)
        {
            _prdouctBrandRepository = prdouctBrandRepository;
            _mapper = mapper;
        }

      

        public async Task AddPrdouctBrand(PrdouctBrandDto PrdouctBrandDto)
        {
            var prdouctBrandDto = _mapper.Map<PrdouctBrandDto, PrdouctBrand>(PrdouctBrandDto);
            await _prdouctBrandRepository.AddAsync(prdouctBrandDto);
        }

        

        public async Task DeletePrdouctBrand(int id)
        {
            await _prdouctBrandRepository.DeleteAsync(id);
        }

        

        public async Task<IEnumerable<PrdouctBrandDto>> GetAllPrdouctBrands()
        {
            var prdouctBrands = await _prdouctBrandRepository.GetAllAsync();
            var mappedPrdouctBrand = _mapper.Map<IEnumerable<PrdouctBrand>, IEnumerable<PrdouctBrandDto>>(prdouctBrands);
            return mappedPrdouctBrand;
        }

      

        public async Task<PrdouctBrandDto> GetPrdouctBrand(int id)
        {
            var prdouctBrand = await _prdouctBrandRepository.GetAsync(id);
            var prdouctBrandDto = _mapper.Map<PrdouctBrand, PrdouctBrandDto>(prdouctBrand);
            return prdouctBrandDto;
        }

        public async Task<IEnumerable<PrdouctBrandDto>> ProductBrandCategoryAsync(int id)
        {
            var prdouctBrands = await _prdouctBrandRepository.ProductBrandCategoryAsync(id);
            var mappedPrdouctBrand = _mapper.Map<IEnumerable<PrdouctBrand>, IEnumerable<PrdouctBrandDto>>(prdouctBrands);
            return mappedPrdouctBrand;
           
        }

        public async Task UpdatePrdouctBrand(PrdouctBrandDto prdouctBrandDto)
        {
            var prdouctBrand = _mapper.Map<PrdouctBrandDto, PrdouctBrand>(prdouctBrandDto);
            await _prdouctBrandRepository.UpdateAsync(prdouctBrand);
        }
    }
}
