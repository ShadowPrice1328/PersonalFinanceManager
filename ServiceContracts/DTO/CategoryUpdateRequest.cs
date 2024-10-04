using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents a DTO class for category updating
    /// </summary>
    public class CategoryUpdateRequest
    {
        [Required(ErrorMessage = "Id cannot be blank.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank.")]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Category ToCategory()
        {
            return new Category
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }
}
