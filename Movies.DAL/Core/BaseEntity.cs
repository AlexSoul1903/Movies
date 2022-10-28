using System;


namespace Movies.DAL.Core
{
 public abstract class BaseEntity
    {
        
        public BaseEntity()
        {

            this.CreationDate = DateTime.Now;
            
        }

        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }




    }
}
