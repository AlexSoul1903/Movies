using System;
namespace Movies.DAL.Core
{
    public abstract class User:BaseEntity
    {

        public string Email { get; set; }
        public string Password { get; set; }


    }
}
