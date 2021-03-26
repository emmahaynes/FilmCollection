using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class EFFilmsRepository : IFilmsRepository
    {
        private FilmListContext _context;

        //constructor
        public EFFilmsRepository(FilmListContext context)
        {
            _context = context;
        }

        public IQueryable<FormResponse> Films => _context.FormResponses; //Allow books to be iterable
    }
}
