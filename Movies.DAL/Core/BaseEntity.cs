using System;


namespace Movies.DAL.Core
{
 public abstract class BaseEntity
    {
        
        public BaseEntity()
        {

            this.Deleted=false;
            this.CreationDate = DateTime.Now;

            this.Rented = false;
            this.Sold = false;
            this.SoldDate = DateTime.Now;

            this.RentedDate = DateTime.Now;
           
        }

        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }

        public int? UserDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool Deleted { get; set; }

        public int CreationMovie { get; set; }

        public int? MovieMod { get; set; }

        public int SoldMovie { get; set; }

        public int? RentMovie { get; set; }

        public bool Sold { get; set; }

        public DateTime? SoldDate { get; set; }

        public bool Rented { get; set; }

        public DateTime? RentedDate { get; set; }


    }
}
