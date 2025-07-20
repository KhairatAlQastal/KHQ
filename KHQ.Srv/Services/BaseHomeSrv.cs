using AutoMapper;
using KHQ.Domain.DTOs;
using KHQ.Domain.Entities;
using KHQ.Domain.ViewModel;
using KHQ.Repo.Repositories;
using KHQ.Repo.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public class BaseHomeSrv : IBaseHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseHomeSrv(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BaseHomeVM>> GetAllAsync()
        {
            var entities = await _unitOfWork.Repository<BaseHome>().GetAllAsync();
            return _mapper.Map<IEnumerable<BaseHomeVM>>(entities);
        }

        public async Task<BaseHomeVM?> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Repository<BaseHome>().GetByIdAsync(id);
            return entity != null ? _mapper.Map<BaseHomeVM>(entity) : null;
        }

        public async Task<int> AddAsync(BaseHomeVM dto)
        {
            var result = 0;
            var entity = _mapper.Map<BaseHome>(dto);
            await _unitOfWork.Repository<BaseHome>().AddAsync(entity);
            result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateAsync(BaseHomeVM dto)
        {
            var result = 0;
            var existing = await _unitOfWork.Repository<BaseHome>().GetByIdAsync(dto.Id);
            if (existing == null)
                throw new Exception("Record not found");

            var entity = _mapper.Map(dto, existing); // map into the existing entity
            _unitOfWork.Repository<BaseHome>().Update(entity);
            result = await _unitOfWork.SaveChangesAsync();
            return result;
        }


        public async Task<int> DeleteAsync(Guid id)
        {
            var result = 0;
            var entity = await _unitOfWork.Repository<BaseHome>().GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.Repository<BaseHome>().Delete(entity);
                result = await _unitOfWork.SaveChangesAsync();
            }
            return result;
        }

        public IQueryable<BaseHome> Queryable()
        {
            return _unitOfWork.Repository<BaseHome>().Queryable();
        }


        public async Task<BaseHomeVM> GetSectionDataAsync(string sectionType)
        {
            var entities = await _unitOfWork.Repository<BaseHome>().GetAllAsync();

            var entity = entities.FirstOrDefault();

            if (entity == null) return null;

            return _mapper.Map<BaseHomeVM>(entity);
        }

        public async Task<int> SaveSectionAsync(SaveSectionRequest request)
        {
            var entities = await _unitOfWork.Repository<BaseHome>().GetAllAsync();
            var entity = entities.FirstOrDefault();

            if (entity == null)
            {
                entity = new BaseHome { Id = Guid.NewGuid() };
                await _unitOfWork.Repository<BaseHome>().AddAsync(entity);
            }
            else
            {
                // Update existing entity
                _unitOfWork.Repository<BaseHome>().Update(entity);
            }

            // Update the specific section based on sectionType
            switch (request.SectionType)
            {
                case "AboutUs":
                    entity.AboutUsTitleEN = request.TitleEn;
                    entity.AboutUsTitleAR = request.TitleAr;
                    entity.AboutUsDescreptionEN = request.DescriptionEn;
                    entity.AboutUsDescreptionAR = request.DescriptionAr;
                    break;
                case "Category":
                    entity.CategoryTitleEn = request.TitleEn;
                    entity.CategoryTitleAr = request.TitleAr;
                    entity.CategoryDescriptionEn = request.DescriptionEn;
                    entity.CategoryDescriptionAr = request.DescriptionAr;
                    break;
                case "FAQ":
                    entity.FAQTitleEn = request.TitleEn;
                    entity.FAQTitleAr = request.TitleAr;
                    entity.FAQDescriptionEn = request.DescriptionEn;
                    entity.FAQDescriptionAr = request.DescriptionAr;
                    break;
                case "Brands":
                    entity.BrandsTitleEn = request.TitleEn;
                    entity.BrandsTitleAr = request.TitleAr;
                    entity.BrandsDescriptionEn = request.DescriptionEn;
                    entity.BrandsDescriptionAr = request.DescriptionAr;
                    break;
            }

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}

public class SaveSectionRequest
{
    public Guid? Id { get; set; }
    public string SectionType { get; set; }
    public string TitleEn { get; set; }
    public string TitleAr { get; set; }
    public string DescriptionEn { get; set; }
    public string DescriptionAr { get; set; }
}