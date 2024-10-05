﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CategoryRepository :  RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CreateOneCategory(Category category) => Create(category);

        public void DeleteCategory(Category category) => Delete(category);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.CategoryId.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        public void UpdateCategory(Category category) => Update(category);
    }
}
