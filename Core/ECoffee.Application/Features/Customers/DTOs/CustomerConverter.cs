using ECoffee.Application.Features.Customers.Commands.Add;
using ECoffee.Application.Features.Customers.Commands.Update;
using ECoffee.Domain.Entities;

namespace ECoffee.Application.Features.Customers.DTOs
{
    public static class CustomerConverter
    {

        //public static CustomerDTO CustomerToCustomerDTO(Customer customer)
        //    => new() { Id = customer.Id, Name = customer.Name, Surname = customer.Surname, Email = customer.Email };

        //public static Customer AddCustomerDTOToCustomer(AddCustomerDTO addCustomerDTO)
        //    => new() { Name = addCustomerDTO.Name, Email = addCustomerDTO.Email, Surname = addCustomerDTO.Surname ,Password=addCustomerDTO.Password};

        //public static GetByIdCustomerDTO CustomerToGetByIdCustomerDTO(Customer customer)
        //    => new()
        //    {
        //        Id = customer.Id,
        //        Name = customer.Name,
        //        Surname = customer.Surname,
        //        Email = customer.Email
        //    };

        //public static List<GetAllCustomersDTO> CustomerListToGetAllCustomersDTO(List<Customer> customers)
        //    => customers.Select(c =>
        //    new GetAllCustomersDTO
        //    {
        //        Id = c.Id,
        //        Email = c.Email,
        //        Name = c.Name,
        //        Surname = c.Surname
        //    }).ToList();

        //public static AddCustomerDTO AddCustomerCommandRequestToAddCustomerDTO(AddCustomerCommandRequest addCustomerCommandRequest)
        //=> new() { Email = addCustomerCommandRequest.Email, Name = addCustomerCommandRequest.Name, Surname = addCustomerCommandRequest.Surname };

        //public static UpdateCustomerDTO UpdateCustomerCommandRequestToUpdateCustomerDTO(UpdateCustomerCommandRequest updateCustomerCommandRequest)
        //    => new() { Id = updateCustomerCommandRequest.Id, Name = updateCustomerCommandRequest.Name, Surname = updateCustomerCommandRequest.Surname, Email = updateCustomerCommandRequest.Email };

        //public static Customer GetByIdCustomerDTOToCustomer(GetByIdCustomerDTO getByIdCustomerDTO)
        //    => new() { Id = getByIdCustomerDTO.Id, Name = getByIdCustomerDTO.Name, Surname = getByIdCustomerDTO.Surname, Email = getByIdCustomerDTO.Email };
    }
}
