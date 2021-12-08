namespace Catalog.Dtos
{
    // This is useful because we can reduce the number of method calls. It is a lot better to pass 
    public record ItemDto
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