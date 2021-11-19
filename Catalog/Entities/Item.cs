namespace Catalog.Entities
{
    public record Item
    {
        public Guid Id{get; init;} //after its creation, it is not possible to modify this property
        public string Name{get; init;}
        public decimal Price {get; init;}
        public DateTimeOffset CreatedDate{get; init;}

    }
}