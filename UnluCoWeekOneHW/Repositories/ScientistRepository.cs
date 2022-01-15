using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekOneHW.Entities;

namespace UnluCoWeekOneHW.Repositories
{
    public class ScientistRepository
    {
        public List<Scientist> scientistsDb = new List<Scientist>()
        {
            new Scientist
            {
                ScientistId=1,
                ScientistName="Albert",
                ScientistSecondName="Einstein",
                ScientistFieldOfStudy="theoretical physics",
                ScientistNationality="Germany",
                Popularity=1200,
                ScientistUniversity="University Of Zurich",
                isActive=true
            },
                  new Scientist
            {
                ScientistId=2,
                ScientistName="Max",
                ScientistSecondName="Planck",
                ScientistFieldOfStudy="theoretical physics",
                ScientistNationality="Germany",
                Popularity=1000,
                ScientistUniversity="Ludwig Maximilian University of Munich",
                isActive=true
            },
                        new Scientist
            {
                ScientistId=3,
                ScientistName="Marie Salomea Skłodowska",
                ScientistSecondName="Curie ",
                ScientistFieldOfStudy="physicist and chemist ",
                ScientistNationality="Germany",
                Popularity=1100,
                ScientistUniversity="University of Paris",
                isActive=true

            }
        };

        public  IEnumerable<Scientist> GetAllScientists ()
        {
            var scientistList = scientistsDb.OrderBy(a => a.ScientistName).ToList();
            return scientistList;
        }


        public IEnumerable<Scientist> FinderById(int id)
        {
            var scientistList = scientistsDb.Where(a => a.ScientistId == id).ToList();
            return scientistList;
        }


    }
}
