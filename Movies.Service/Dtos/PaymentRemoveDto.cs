﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Dtos
{
    public class PaymentRemoveDto : Core.BaseDto
    {
        public DateTime DeletedDate { get; set; }
    }
}
