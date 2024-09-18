using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyOpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Frameworks;

namespace TrophyOpg.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {

        private TrophiesRepository _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = new TrophiesRepository();
        }



        [TestMethod()]
        public void GetAllTest()
        {
            Trophy trophy1 = new Trophy(17, "circus", 2000);
            Trophy trophy2 = new Trophy(17, "Circuss", 2000);
            Trophy trophy3 = new Trophy(17, "circus 500", 2000);
            Trophy trophy4 = new Trophy(17, "dance", 2000);
            Trophy trophy5 = new Trophy(17, "dances", 2000);
            Assert.AreEqual(0, _repo.Get().Count);
            _repo.Add(trophy1);
            _repo.Add(trophy2);
            _repo.Add(trophy3);
            _repo.Add(trophy4);
            _repo.Add(trophy5);
            Assert.AreEqual(5, _repo.Get().Count);


        }

        [TestMethod()]
        public void GetByYearTest()
        {
            Trophy trophy1 = new Trophy(17, "circus", 1980);
            Trophy trophy2 = new Trophy(17, "Circuss", 1990);
            Trophy trophy3 = new Trophy(17, "circus 500", 2000);
            Trophy trophy4 = new Trophy(17, "dance", 2010);
            Trophy trophy5 = new Trophy(17, "dances", 2020);
            _repo.Add(trophy1);
            _repo.Add(trophy2);
            _repo.Add(trophy3);
            _repo.Add(trophy4);
            _repo.Add(trophy5);

            int before2010 = _repo.Get(yearBefore:2010).Count;
            Assert.AreEqual(3, before2010);
            int after2000 = _repo.Get(yearAfter: 2000).Count;
            Assert.AreEqual(2, after2000);
            int from1990To2020 = _repo.Get(yearBefore: 2020, yearAfter: 1990).Count;
            Assert.AreEqual(2,from1990To2020);
            int from1970To2024 = _repo.Get(yearBefore: 2024, yearAfter: 1970).Count;
            Assert.AreEqual(5,from1970To2024);

        }
      

        [TestMethod()]
        public void GetByCompTest()
        {
            Trophy trophy1 = new Trophy(17, "circus", 2000);
            Trophy trophy2 = new Trophy(17, "Circuss", 2000);
            Trophy trophy3 = new Trophy(17, "circus 500", 2000);
            Trophy trophy4 = new Trophy(17, "dance", 2000);
            Trophy trophy5 = new Trophy(17, "dances", 2000);
            _repo.Add(trophy1);
            _repo.Add(trophy2);
            _repo.Add(trophy3);
            _repo.Add(trophy4);
            _repo.Add(trophy5);

            int circus = _repo.Get(competition: "circus").Count();
            Assert.AreEqual(3, circus);
            int circuss = _repo.Get(competition: "circuss").Count();
            Assert.AreEqual(1, circuss);
            int dance = _repo.Get(competition: "DancE").Count();
            Assert.AreEqual(2, dance);

        }

        [TestMethod()]
        public void GetSortTest()
        {
            Trophy trophy1 = new Trophy(17, "rircus", 1999);
            Trophy trophy2 = new Trophy(17, "stuff", 2020);
            Trophy trophy3 = new Trophy(17, "circus 500", 2000);
            Trophy trophy4 = new Trophy(17, "circus", 2024);
            Trophy trophy5 = new Trophy(17, "dance", 1998);
            _repo.Add(trophy1);
            _repo.Add(trophy2);
            _repo.Add(trophy3);
            _repo.Add(trophy4);
            _repo.Add(trophy5);

            Assert.AreEqual("circus",_repo.Get(sortBy:SortType.Competition).First().Competition);
            Assert.AreEqual("stuff", _repo.Get(sortBy: SortType.Competition, ascending: false).First().Competition);

            Assert.AreEqual(1998, _repo.Get(sortBy: SortType.Year).First().Year);
            Assert.AreEqual(2024, _repo.Get(sortBy: SortType.Year, ascending: false).First().Year);

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Trophy trophy1 = new Trophy(17, "navn", 2000);
            Trophy trophy2 = new Trophy(13, "navn", 2000);
            _repo.Add(trophy1);
            _repo.Add(trophy2);

            Assert.AreEqual(trophy1, _repo.GetById(1));
            Assert.AreEqual(trophy2, _repo.GetById(2));
            Assert.IsNull(_repo.GetById(3));
        }

        [TestMethod()]
        public void AddTest()
        {
            Trophy trophy1 = new Trophy(17, "navn", 2000);
            Trophy trophy2 = new Trophy(13, "navn", 2000);
            Trophy trophyFail = new Trophy(11, "navn", 2025);
          
            int countBefore = _repo.Count;
            _repo.Add(trophy1);
            int countAfter = _repo.Count;
            Assert.AreEqual(countBefore + 1, countAfter);
            Assert.AreEqual(1, trophy1.Id);

            _repo.Add(trophy2);
            Assert.AreEqual(2, trophy2.Id);

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>_repo.Add(trophyFail));

        }

        [TestMethod()]
        public void RemoveTest()
        {
            Trophy trophy1 = new Trophy(10, "navn", 2000);
            _repo.Add(trophy1);
            int countBefore = _repo.Count;
            Trophy deletedTrophy = _repo.Remove(1);
            int countAfter = _repo.Count;
            Assert.AreEqual(countBefore - 1, countAfter);
            Assert.AreEqual(trophy1, deletedTrophy);

            Assert.IsNull(_repo.Remove(1));

        }


        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}