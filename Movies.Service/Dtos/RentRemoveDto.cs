﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Dtos
{
    public class RentRemoveDto : Core.DtoClientBase
    {
        public int Id { get; set; }


        public DateTime DeletedDate { get; set; }

    }
}
