

using System.Runtime.CompilerServices;

namespace Movies.Service.Core
{
    public class ServiceResult
    {

        public ServiceResult()
        {

            this.Success = true;

        }

        public bool Success { get; set; }

        
        public string Message { get; set; }

        public dynamic Data { get; set; }

    }
}
