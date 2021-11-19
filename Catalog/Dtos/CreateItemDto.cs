namespace Catalog.Dtos
{
    public record CreateItemDto{
        
        private string?  _name;
        public string? Name
        {
            get => _name; 
            init => _name = value ?? throw new ArgumentNullException(Constants.ErrorNullValue);}
        public decimal Price{get; init;}
    }
}