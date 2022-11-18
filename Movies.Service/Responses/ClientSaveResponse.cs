
namespace Movies.Service.Responses
{
    public class ClientSaveResponse: Core.ServiceResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Password { get; set; }

    }
}
