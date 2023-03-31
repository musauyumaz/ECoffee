using ECoffee.Domain.Entities;

namespace ECoffee.Application.Features.Customers.DTOs
{
    public static class CustomerConverter
    {
<<<<<<< Updated upstream
        public static CustomerDTO CustomerTCustomerDTO(Customer customer)
            => new() {Name=customer.Name,Surname=customer.Surname,Email=customer.Email };
=======
        public static CustomerDTO CustomerToCustomerDTO(Customer customer)
            => new() {Id=customer.Id,Name=customer.Name,Surname=customer.Surname,Email=customer.Email };
>>>>>>> Stashed changes
        public static Customer AddCustomerDTOToCustomer(AddCustomerDTO addCustomerDTO)
            => new() { Name = addCustomerDTO.Name, Email = addCustomerDTO.Email ,Surname=addCustomerDTO.Surname};
        public static Customer UpdateCustomerDTOToCustomer(UpdateCustomerDTO updateCustomerDTO)
            => new() { Id=updateCustomerDTO.Id, Name=updateCustomerDTO.Name,Surname=updateCustomerDTO.Surname,Email=updateCustomerDTO.Email,IsActive=updateCustomerDTO.IsActive };

        public static GetByIdCustomerDTO CustomerToGetByIdCustomerDTO(Customer customer)
            => new() {Id= customer.Id, Name =customer.Name,Surname= customer.Surname,Email= customer.Email};

        public static List<GetAllCustomersDTO> CustomerListToGetAllCustomersDTO(List<Customer> customers)
            => customers.Select(c => new GetAllCustomersDTO { Id = c.Id, Email = c.Email, Name = c.Name, Surname = c.Surname }).ToList();
    }
}
