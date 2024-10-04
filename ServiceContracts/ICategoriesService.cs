using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICategoriesService
    {
        /// <summary>
        /// Retrives all categories presented in database
        /// </summary>
        /// <returns>A list of CategoryResponse objects</returns>
        List<CategoryResponse> GetCategories();

        /// <summary>
        /// Retrives selected category according to id
        /// </summary>
        /// <param name="categoryId">Id of category to get</param>
        /// <returns>CategoryResponse with all the information about selected category</returns>
        CategoryResponse? GetCategoryByCategoryId(Guid? categoryId);

        /// <summary>
        /// Adds category to database
        /// </summary>
        /// <param name="request">Category to add</param>
        /// <returns>The same details but with generated Guid</returns>
        CategoryResponse AddCategory(CategoryAddRequest? request);

        /// <summary>
        /// Updates information about category 
        /// </summary>
        /// <param name="request">Category to update</param>
        /// <returns>CategoryResponse with updated information about category</returns>
        CategoryResponse UpdateCategory(CategoryUpdateRequest request);

        /// <summary>
        /// Removes category from database
        /// </summary>
        /// <param name="guid">Id of category to remove</param>
        /// <returns>True if success, false if error has occured</returns>
        bool DeleteCategory(Guid? guid);
    }
}
