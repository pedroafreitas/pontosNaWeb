using System;

namespace Catalog.Entities
{
    public record Item
    {
        public Guid Id{get; init;} //after its creation, it is not possible to modify this property

        private string? _name; 
        public string? Name
        {
            get => _name;
            init => _name = value ?? throw new ArgumentNullException(Constants.ErrorNullValue);
        }

        public decimal Price {get; init;}
        public DateTimeOffset CreatedDate{get; init;}

    }
}