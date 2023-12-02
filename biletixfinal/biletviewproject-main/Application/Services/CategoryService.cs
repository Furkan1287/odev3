using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<CommandResult<IEnumerable<CategoryDetailDto>>> GetCategories();
        Task<CommandResult<CategoryDetailDto>> GetCategoryById(Guid id);
        Task<CommandResult> AddCategory(CategoryDetailDto categoryDto);
        Task<CommandResult> UpdateCategory(Guid id, CategoryDetailDto updatedCategoryDto);
        Task<CommandResult> DeleteCategory(Guid id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepositoryAsync<Category> _categoryRepository;
        private readonly IMapper _mapper;

        Expression<Func<Category, object>>[] includes = new Expression<Func<Category, object>>[] { };

        public CategoryService(IGenericRepositoryAsync<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult<IEnumerable<CategoryDetailDto>>> GetCategories()
        {
            var categoryList = await _categoryRepository.GetAllAsync(includes);
            var data = _mapper.Map<IEnumerable<CategoryDetailDto>>(categoryList);
            return new SuccessCommandResult<IEnumerable<CategoryDetailDto>>(data);
        }

        public async Task<CommandResult<CategoryDetailDto>> GetCategoryById(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id, includes);
            if (category == null)
            {
                return new NotFoundCommandResult<CategoryDetailDto>("Category not found");
            }

            var data = _mapper.Map<CategoryDetailDto>(category);
            return new SuccessCommandResult<CategoryDetailDto>(data);
        }

        public async Task<CommandResult> AddCategory(CategoryDetailDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            return new SuccessCommandResult("Category added successfully");
        }

        public async Task<CommandResult> UpdateCategory(Guid id, CategoryDetailDto updatedCategoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new NotFoundCommandResult("Category not found");
            }

            _mapper.Map(updatedCategoryDto, category);
            await _categoryRepository.UpdateAsync(category);
            return new SuccessCommandResult("Category updated successfully");
        }

        public async Task<CommandResult> DeleteCategory(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new NotFoundCommandResult("Category not found");
            }

            await _categoryRepository.DeleteAsync(category);
            return new SuccessCommandResult("Category deleted successfully");
        }
    }
}
