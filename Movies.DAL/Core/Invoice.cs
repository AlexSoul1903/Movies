using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Core
{
    public class Invoice: BaseEntity
    {
        public int PaymentId { get; set; }
    }
}
