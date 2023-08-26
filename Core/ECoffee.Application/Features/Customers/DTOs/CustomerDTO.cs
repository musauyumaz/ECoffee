using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Customers.DTOs
{
    public class CustomerDTO : IDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string FullName => $"{Name} {Surname}";
        //todo IsActive i de çagırabiliriz //Serkan
    }
}