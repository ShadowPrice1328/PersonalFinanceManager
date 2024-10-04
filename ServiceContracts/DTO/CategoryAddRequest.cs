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
    /// Represents a DTO class for adding a Category objects to database
    /// </summary>
    public class CategoryAddRequest
    {
        [Required(ErrorMessage = "Name cannot be blank.")]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Category ToCategory()
        {
            return new Category
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
