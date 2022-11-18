using Movies.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Dtos
{
   public class ClientUpdateDto:DtoClientBase
    {
        public DateTime? UpdatedDate { get; set; }



    }
}
