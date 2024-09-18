using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrophyOpg
{
    public class Trophy
    {

        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public Trophy()
        {
            
        }

        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
            
        }

        public void ValidateCompetition()
        {
            if (Competition == null)
            {
                throw new ArgumentNullException("Competition","Competition cannot be null");
            }
            if (Competition.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Competition", "Competition name has to be 3 characters or longer");
            }

        }

        public void ValidateYear()
        {
            if (Year <= 1969 || Year > 2024) 
            {
                throw new ArgumentOutOfRangeException("Year", "Year has to be between 1970 and 2024");
            }

        }

        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }

        public override string ToString()
        {
            return $"Trophy info: ID: {Id}, Competition: {Competition}, Year: {Year}";
        }




    }
}
