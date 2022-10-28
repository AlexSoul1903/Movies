using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.DAL.Entities
{

    [Table("Clients", Schema = "dbo")]

    public class Clients : Core.User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? PaymentMethodId { get; set; }

    }
}
