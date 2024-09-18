using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrophyOpg
{

    public enum SortType { Competition, Year };

    public class TrophiesRepository
    {

        private List<Trophy> _trophies;
        private int _nextId = 0;

        public int Count { get { return _trophies.Count; } }

        public TrophiesRepository()
        {
            _trophies = new List<Trophy>();
            
        }

        
        public List<Trophy> Get(int? yearAfter = null, int? yearBefore = null, string? competition = null, 
            SortType? sortBy = null, bool? ascending = true)
        {
            List<Trophy> trophyList = new List<Trophy>(_trophies);

            if (yearAfter != null)
            {
                trophyList = trophyList.FindAll(x => x.Year >  yearAfter);
            }
            if (yearBefore != null)
            {
                trophyList = trophyList.FindAll(x=>x.Year < yearBefore);
            }
            if (competition != null)
            { 
                competition = competition.ToLower(); 
                trophyList = trophyList.FindAll(x => x.Competition.Contains(competition));
            }
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case SortType.Competition:
                        trophyList = trophyList.OrderBy(x => x.Competition).ToList();
                        break;
                    case SortType.Year:
                        trophyList = trophyList.OrderBy(x=> x.Year).ToList();
                        break;
                }
            }
            if (ascending == false)
            {
                trophyList.Reverse();
            }

            return trophyList;

        }

        public Trophy? GetById(int id)
        {
            Trophy trophy = _trophies.Find(x => x.Id == id);
            if (trophy == null)
            {
                return null;
            }
            return trophy;

        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();
            _nextId++;
            trophy.Id = _nextId;
            trophy.Competition = trophy.Competition.ToLower();
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy Remove(int id)
        {
            Trophy trophyToRemove = GetById(id);
            if (trophyToRemove == null)
            {
                return null;
            }
            else
            {
                _trophies.Remove(trophyToRemove);
                return trophyToRemove;
            }
        }

        public Trophy Update(int id, Trophy trophy)
        {
            trophy.Validate();
            Trophy trophyToUpdate = GetById(id);
            if (trophyToUpdate == null)
            {
                return null;
            }
            trophyToUpdate.Competition = trophy.Competition;
            trophyToUpdate.Year = trophy.Year;
            return trophyToUpdate;

        }



    }



}
