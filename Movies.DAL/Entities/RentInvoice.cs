﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Entities
{
    public class RentInvoice: Core.Invoice
    {
        public int RentId { get; set; }
    }
}
