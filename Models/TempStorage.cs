using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Emma Haynes 2.3.21

namespace FilmCollection.Models
{
    public static class TempStorage
        //puts information from the film form into a list and in temporary storage
    {
        private static List<FormResponse> forms = new List<FormResponse>();

        public static IEnumerable<FormResponse> Forms => forms;

        public static void AddMovie(FormResponse form)
        {
            forms.Add(form);
        }
    }
}
