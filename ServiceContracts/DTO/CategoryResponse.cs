using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents a DTO for responses from category-related operations.
    /// </summary>
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public CategoryUpdateRequest ToUpdateRequest()
        {
            return new CategoryUpdateRequest
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }

    public static class CategoryExtentions
    {
        public static CategoryResponse ToCategoryResponse(this Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
