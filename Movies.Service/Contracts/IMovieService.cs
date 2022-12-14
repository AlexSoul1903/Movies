using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Contracts
{
    public interface IMovieService : IBaseService
    {
        public MovieSaveResponse Save(MovieSaveDto dto);

        public MovieUpdateResponse Update (MovieUpdateDto dto);

        public MovieDeleteResponse Remove(MovieRemoveDto dto);
    }
}
