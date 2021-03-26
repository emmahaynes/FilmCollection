using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public interface IFilmsRepository //interface meant to be inherited
    {
        IQueryable<FormResponse> Films { get; }
    }
}
