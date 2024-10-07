using Services.Data;
using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Services.Helpers;

namespace Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDbContext _appDbContext;
        private readonly List<Category> _categories;
        public CategoriesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _categories = _appDbContext.Categories.ToList();
        }

        public CategoryResponse AddCategory(CategoryAddRequest? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            ValidationHelper.ModelValidation(request);

            if (_categories != null && _categories.Where(c => c.Name == request.Name).Any())
            {
                throw new ArgumentException("This category already exists");
            }

            Category category = request.ToCategory();
            category.Id = Guid.NewGuid();

            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();

            return category.ToCategoryResponse();
        }

        public bool DeleteCategory(Guid? guid)
        {
            if (!guid.HasValue) throw new ArgumentNullException(nameof(guid));
                
            Category? category = _categories.FirstOrDefault(g => g.Id == guid.Value);

            if (category == null)
                return false;

            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();

            return true;
        }

        public List<CategoryResponse> GetCategories()
        {
            return _categories.Select(c => c.ToCategoryResponse()).ToList();
        }

        public CategoryResponse? GetCategoryByCategoryId(Guid? categoryId)
        {
            if (!categoryId.HasValue) throw new ArgumentNullException(nameof(categoryId));

            return _categories.FirstOrDefault(c => c.Id == categoryId)?.ToCategoryResponse() ?? null;
        }

        public List<string?> GetCategoryNames()
        {
            return _appDbContext.Categories.Select(c => c.Name).ToList() ?? new List<string>();
        }


        public List<CategoryResponse> GetFilteredCategories(string filterBy, string? filterString)
        {
            List<CategoryResponse> allCategories = GetCategories();
            List<CategoryResponse> filteredCategories = allCategories;

            if (string.IsNullOrEmpty(filterBy) || string.IsNullOrEmpty(filterString))
                return filteredCategories;

            switch(filterBy)
            {
                case nameof(Category.Name):
                    filteredCategories = allCategories.Where(c => string.IsNullOrEmpty(c.Name) ||
                    c.Name.StartsWith(filterString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                    break;

                case nameof(Category.Description):
                    filteredCategories = allCategories.Where(c => string.IsNullOrEmpty(c.Name) ||
                    c.Name.Contains(filterString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                    break;

                default: filteredCategories = allCategories; break;
            }

            return filteredCategories;
        }

        public CategoryResponse UpdateCategory(CategoryUpdateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(CategoryUpdateRequest));

            ValidationHelper.ModelValidation(request);

            Category? category = _categories.FirstOrDefault(c => c.Id == request.Id) 
                ?? throw new ArgumentNullException(nameof(request), "Category with given Id does not exist");

            category.Name = request.Name;
            category.Description = request.Description;

            var relatedTransactions = _appDbContext.Transactions.Where(t => t.Category == request.Name).ToList();

            if (relatedTransactions.Any())
            {
                foreach (var transaction in relatedTransactions)
                {
                    transaction.Category = request.Name;
                    transaction.Description = request.Description;
                }
            }

            _appDbContext.SaveChanges();

            return category.ToCategoryResponse();
        }
    }
}
