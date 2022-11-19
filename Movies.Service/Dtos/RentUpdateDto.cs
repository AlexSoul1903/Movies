﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Dtos
{
    public class RentUpdateDto : Core.DtoClientBase
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public double RentPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
