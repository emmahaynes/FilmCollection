using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public static class TempStorage
    {
        private static List<FormResponse> forms = new List<FormResponse>();

        public static IEnumerable<FormResponse> Forms => forms;

        public static void AddMovie(FormResponse form)
        {
            forms.Add(form);
        }
    }
}
