using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        private string _name;
        [Required]
        public string Name
        {
            get => _name;
            init => _name = value ?? throw new ArgumentNullException(Constants.ErrorNullValue);
        }

        [Required]
        [Range(1,1000)]
        public decimal Price {get; init;}
    }
}