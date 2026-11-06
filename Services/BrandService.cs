using System;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Backend.Services;

public class BrandService : ICommonService<BrandDto, BrandInsertDto, BrandUpdateDto>
{
    private IRepository<Brand> _brandRepository;

    public BrandService(IRepository<Brand> brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<BrandDto>> Get()

    {
        var brands = await _brandRepository.Get();
        return brands.Select(
                b => new BrandDto
                {
                    BrandId = b.BrandId,
                    Name = b.Name,
                }
         );
    }
    public async Task<BrandDto> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand != null)
        {
            var brandDto = new BrandDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,

            };
            return brandDto;
        }
        return null;
    }

    public async Task<BrandDto> Add(BrandInsertDto brandInsertDto)
    {
        var brand = new Brand()
        {
            Name    = brandInsertDto.Name,
        
           
        };
        await _brandRepository.Add(brand);
        await _brandRepository.save();
        var brandDto = new BrandDto()
        {
            BrandId = brand.BrandId,
            Name    = brand.Name,
        };
        return brandDto;
    }

    public async Task<BrandDto> Update(int id, BrandUpdateDto brandUpdateDto)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand != null)
        {
            brand.Name = brandUpdateDto.Name;
            _brandRepository.Update(brand);
            await _brandRepository.save();
            var brandDto = new BrandDto()
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
              
            };
            return brandDto;
        }

        return null;
    }
    public async Task<BrandDto> Delete(int id)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand != null)
        {
            _brandRepository.Delete(brand);
            await _brandRepository.save();
            var brandDto = new BrandDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
            };
            return brandDto;
        }

        return null;
    }


}
