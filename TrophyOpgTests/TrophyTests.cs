using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyOpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyOpg.Tests
{
    [TestClass()]
    public class TrophyTests
    {
   

        [TestMethod()]
        public void ValidateCompetitionTest()
        {
            Trophy trophy1 = new Trophy(1,"to",1999);
            Trophy trophy2 = new Trophy(2, null, 1999);
            Trophy trophy3 = new Trophy(3, "tre", 1999);
            Trophy trophy4 = new Trophy(4, "fire", 1999);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy1.ValidateCompetition());
            Assert.ThrowsException<ArgumentNullException>(() => trophy2.ValidateCompetition());
            trophy3.ValidateCompetition();
            trophy4.ValidateCompetition();

        }

        [TestMethod()]
        public void ValidateYearTest()
        {
            Trophy trophy1969 = new Trophy(1, "too", 1969);
            Trophy trophy1970 = new Trophy(2, "too", 1970);
            Trophy trophy1999 = new Trophy(3, "too", 1999);
            Trophy trophy2024 = new Trophy(4, "too", 2024);
            Trophy trophy2025 = new Trophy(1, "too", 2025);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy1969.ValidateYear());
            trophy1970.ValidateYear();
            trophy1999.ValidateYear();
            trophy2024.ValidateYear();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy2025.ValidateYear());

        }

        [TestMethod()]
        public void ValidateTest()
        {
            Trophy trophy1969 = new Trophy(1, "too", 1969);
            Trophy trophy1 = new Trophy(1, "to", 1999);
            Trophy trophy2 = new Trophy(2, null, 1999);
            Trophy trophy2024 = new Trophy(1, "too", 2024);

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> trophy1969.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy1.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => trophy2.Validate());
            trophy2024.Validate();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Trophy trophy = new Trophy(1, "too", 2024);

            Assert.AreEqual("Trophy info: ID: 1, Competition: too, Year: 2024", trophy.ToString());

        }
    }
}